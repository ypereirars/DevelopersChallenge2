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
            var instance = Activator.CreateInstance(_type);

            return instance;
        }
    }
}