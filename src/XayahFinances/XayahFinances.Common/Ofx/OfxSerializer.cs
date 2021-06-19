using System;
using System.Collections;
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
            Regex bodyTagRegex = new Regex(@"<?(\/)?(\w+)[>:]?(.*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex dateRegex = new Regex(@"(\d+)\[([-+]\d+){0,3}.*\]", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            var instance = Activator.CreateInstance(_type);
            ofxTags.Push(instance);

            while ((line = stream.ReadLine()) != null)
            {
                var bodyMatch = bodyTagRegex.Match(line.Trim());

                var attributeName = "";
                string attributeValue = null;
                
                if(bodyMatch.Success)
                {
                    var groups = bodyMatch.Groups;

                    if (groups[1].Value == "/")
                    {
                        var element = ofxTags.Peek();

                        if (element.GetType().GetCustomAttribute<OfxAttribute>()?.Name == groups[2].Value)
                        {
                            ofxTags.Pop();
                        }
                    }
                    else
                    {
                        attributeName = groups[2].Value;
                        attributeValue = groups[3].Value;
                        var element = ofxTags.Peek();

                        var property = element.GetType().GetProperties().FirstOrDefault(prop => prop.GetCustomAttribute<OfxAttribute>(true)?.Name == attributeName);
                        var attribute = property?.GetCustomAttribute<OfxAttribute>();

                        if (property is null)
                            continue;
                        
                        if (property.PropertyType.IsValueType || property.PropertyType == typeof(string))
                        {
                            object value = attributeValue;
                            if(property.PropertyType == typeof(DateTimeOffset))
                            {
                                attributeValue = dateRegex.Replace(attributeValue, "$1 $2");
                                value = DateTimeOffset.ParseExact(attributeValue, "yyyyMMddHHmmss zz", null);
                            }
                            
                            property.SetValue(element, Convert.ChangeType(value, property.PropertyType));
                        }
                        else
                        {
                            var elementInstance = Activator.CreateInstance(property.PropertyType);
                            property.SetValue(element, Convert.ChangeType(elementInstance, property.PropertyType));
                            ofxTags.Push(elementInstance);
                        }
                    }
                }
                else
                {
                    continue;
                }
            }

            return instance;
        }
    }
}