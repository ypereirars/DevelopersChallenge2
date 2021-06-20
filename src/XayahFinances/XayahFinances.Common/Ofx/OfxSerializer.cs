using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using XayahFinances.Common.Ofx.Attributes;

namespace XayahFiances.Common
{
    public class OfxSerializer
    {
        readonly Type _type;

        public OfxSerializer(Type type)
        {
            _type = type;
        }

        public object Deserialize(StreamReader stream)
        {
            string line;
            Stack ofxTags = new Stack();
            Queue ofxQueue = new Queue();

            Regex bodyTagRegex = new Regex(@"<?(\/)?(\w+)[>:]?(.*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            var instance = CreateInstance(_type);

            ofxTags.Push(instance);

            while ((line = stream.ReadLine()) != null)
            {
                var bodyMatch = bodyTagRegex.Match(line.Trim());

                if (bodyMatch.Success)
                {
                    var groups = bodyMatch.Groups;

                    if (groups[1].Value == "/")
                        PopTagIfClosing(ofxTags, groups);
                    else
                    {
                        string attributeName = groups[2].Value;
                        var element = ofxTags.Peek();
                        PropertyInfo property = GetPropertyByAttributeName(attributeName, element);

                        if (property is null)
                            continue;




                        if (property.PropertyType.IsValueType || property.PropertyType == typeof(string))
                        {
                            SetValueToElement(groups[3].Value, element, property);
                        }
                        else
                        {
                            var attribute = GetAttributeFromProperty(property);
                            var elementInstance = InstantiateNewElement(element, property);

                            if (attribute.GetType() == typeof(OfxElementListAttribute))
                            {
                                var el = CreateInstance(property.PropertyType.GenericTypeArguments[0]);

                                ofxTags.Push(el);
                            }
                            else
                            {
                                ofxTags.Push(elementInstance);
                            }

                        }
                    }
                }
            }

            return instance;
        }

        private static object CreateInstance(Type type) => Activator.CreateInstance(type);

        private static void PopTagIfClosing(Stack ofxTags, GroupCollection groups)
        {
            var element = ofxTags.Peek();

            if (GetAttributeFromElement(element)?.Name == groups[2].Value)
            {
                ofxTags.Pop();
                if (ofxTags.Count > 0)
                    AddElementToList(ofxTags, groups, element);
            }
        }

        private static void AddElementToList(Stack ofxTags, GroupCollection groups, object element)
        {
            var listElement = ofxTags.Peek();
            var property = GetPropertyByAttributeName(groups[2].Value, listElement);
            var attribute = GetAttributeFromProperty(property);
            if (attribute.GetType() == typeof(OfxElementListAttribute))
            {
                var obj = property.GetValue(listElement);
                property.PropertyType.GetMethod("Add").Invoke(obj, new[] { element });
            }
        }

        private static OfxAttribute GetAttributeFromElement(object element)
        {
            return element.GetType().GetCustomAttribute<OfxAttribute>();
        }

        private static PropertyInfo GetPropertyByAttributeName(string attributeName, object element)
        {
            return element
                .GetType()
                .GetProperties()
                .FirstOrDefault(prop => GetAttributeFromProperty(prop)?.Name == attributeName);
        }

        private static OfxAttribute GetAttributeFromProperty(PropertyInfo prop)
        {
            return prop.GetCustomAttribute<OfxAttribute>(true);
        }

        private static void SetValueToElement(string attributeValue, object element, PropertyInfo property)
        {
            object value = attributeValue;
            var typeCode = Type.GetTypeCode(property.PropertyType);

            if (property.PropertyType == typeof(DateTimeOffset))
            {
                Regex dateRegex = new Regex(@"(\d+)\[([-+]\d+){0,3}.*\]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                attributeValue = dateRegex.Replace(attributeValue, "$1 $2");
                value = DateTimeOffset.ParseExact(attributeValue, "yyyyMMddHHmmss zz", null);
            }
            else if (property.PropertyType == typeof(decimal))
            {
                value = decimal.Parse((string)attributeValue, CultureInfo.InvariantCulture);
            }

            property.SetValue(element, Convert.ChangeType(value, property.PropertyType));
        }

        private static object InstantiateNewElement(object element, PropertyInfo property)
        {
            var obj = property.GetValue(element);

            if (obj is null)
            {
                var elementInstance = CreateInstance(property.PropertyType);

                property.SetValue(element, Convert.ChangeType(elementInstance, property.PropertyType));
                return elementInstance;
            }

            return obj;
        }
    }
}