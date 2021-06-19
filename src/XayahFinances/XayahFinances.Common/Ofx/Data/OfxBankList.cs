﻿using System;
using System.Collections.Generic;
using System.Text;
using XayahFinances.Common.Ofx.Attributes;

namespace XayahFinances.Common.Ofx.Data
{
    [OfxElement("BANKTRANLIST")]
    public class OfxBankList
    {
        [OfxElement("DTSTART")]
        public DateTimeOffset StartDate { get; set; }
        [OfxElement("DTEND")]
        public DateTimeOffset EndDate { get; set; }
        public IList<OfxTransaction> Transactions { get; set; }
    }
}
