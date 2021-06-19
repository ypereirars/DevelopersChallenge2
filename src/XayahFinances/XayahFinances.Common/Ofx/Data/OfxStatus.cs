namespace XayahFinances.Common.Ofx.Data
{
    using Attributes;

    [OfxElement("STATUS")]
    public class OfxStatus
    {
        [OfxElement("CODE")]
        public int Code { get; set; }

        [OfxElement("SEVERITY")]
        public string Severity { get; set; }
    }
}
