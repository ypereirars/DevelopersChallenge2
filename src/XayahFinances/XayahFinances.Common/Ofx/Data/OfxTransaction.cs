using System;
using XayahFinances.Common.Ofx.Attributes;

namespace XayahFinances.Common.Ofx.Data
{
    public class OfxTransaction
    {
        [OfxElement("TRNTYPE")]
        public string Type { get; set; }
        [OfxElement("DTPOSTED")]
        public DateTimeOffset DatePosted { get; set; }
        [OfxElement("TRNAMT")]
        public decimal Amount { get; set; }
        [OfxElement("MEMO")]
        public string Information { get; set; }
    }
}