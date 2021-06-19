namespace XayahFinances.Common.Ofx.Data
{
    using Attributes;

    [OfxRoot("SIGNONMSGSRSV1")]
    public class OfxSignOnMessage
    {
        [OfxElement("SONRS")]
        public OfxSignOn SignOn { get; set; }
    }
}