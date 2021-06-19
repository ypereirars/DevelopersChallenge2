namespace XayahFinances.Common.Ofx.Data
{
    using System;
    using Attributes;

    [OfxRoot("SONRS")]
    public class OfxSignOn
    {
        [OfxElement("STATUS")]
        public OfxStatus Status { get; private set; }
        [OfxElement("DTSERVER")]
        public DateTimeOffset ServerDate { get; private set; }
        [OfxElement("LANGUAGE")]
        public string Language { get; private set; }
    }
}