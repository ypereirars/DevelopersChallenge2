using System;
using XayahFinances.Common.Ofx.Attributes;

namespace XayahFinances.Common.Ofx.Data
{
    [OfxElement("LEDGERBAL")]
    public class OfxBalance
    {
        [OfxElement("BALAMT")]
        public decimal Amount { get; set; }
        [OfxElement("DTASOF")]
        public DateTimeOffset Date { get; set; }
    }
}