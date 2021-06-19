using System;

namespace XayahFinances.Common.Ofx.Attributes
{
    public abstract class OfxAttribute : Attribute
    {
        public string Name { get; private set; }

        public OfxAttribute(string name) => Name = name;
    }
}
