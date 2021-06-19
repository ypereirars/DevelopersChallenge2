using XayahFinances.Common.Ofx.Attributes;

namespace XayahFinances.Common.Ofx.Data
{
    public class OfxBankMessage
    {
        [OfxElement("STMTTRNRS")]
        public OfxResponseTransaction ResponseTranscation { get; set; }
    }
}
