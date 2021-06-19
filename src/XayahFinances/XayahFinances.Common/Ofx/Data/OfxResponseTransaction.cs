using XayahFinances.Common.Ofx.Attributes;

namespace XayahFinances.Common.Ofx.Data
{
    public class OfxResponseTransaction
    {
        [OfxElement("STMTTRNRS")]
        public int ClientId { get; set; }
        [OfxElement("STATUS")]
        public OfxStatus Status { get; set; }
        [OfxElement("STMTRS")]
        public OfxStatemetResponse Response { get; set; }
    }
}