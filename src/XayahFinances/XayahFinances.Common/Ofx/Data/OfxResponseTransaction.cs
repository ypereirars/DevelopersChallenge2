using XayahFinances.Common.Ofx.Attributes;

namespace XayahFinances.Common.Ofx.Data
{
    [OfxElement("STMTTRNRS")]
    public class OfxResponseTransaction
    {
        [OfxElement("STMTTRNRS")]
        public int ClientId { get; set; }
        [OfxElement("STATUS")]
        public OfxStatus Status { get; set; }
        [OfxElement("STMTRS")]
        public OfxStatementResponse Response { get; set; }
    }
}