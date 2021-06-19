using XayahFinances.Common.Ofx.Attributes;

namespace XayahFinances.Common.Ofx.Data
{
    [OfxElement("BANKMSGSRSV1")]
    public class OfxBankMessage
    {
        [OfxElement("STMTTRNRS")]
        public OfxResponseTransaction ResponseTranscation { get; set; }
    }
}
