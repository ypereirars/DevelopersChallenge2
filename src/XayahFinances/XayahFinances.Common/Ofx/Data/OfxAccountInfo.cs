using XayahFinances.Common.Ofx.Attributes;

namespace XayahFinances.Common.Ofx.Data
{
    [OfxElement("BANKACCTFROM")]
    public class OfxAccountInfo
    {
        [OfxElement("BANKID")]
        public string BankId { get; set; }
        [OfxElement("ACCTID")]
        public string AccountNumber { get; set; }
        [OfxElement("ACCTTYPE")]
        public string AccountType { get; set; }
    }
}