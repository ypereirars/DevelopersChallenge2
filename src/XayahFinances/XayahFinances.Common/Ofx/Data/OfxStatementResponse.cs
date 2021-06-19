using XayahFinances.Common.Ofx.Attributes;

namespace XayahFinances.Common.Ofx.Data
{
    [OfxElement("STMTRS")]
    public class OfxStatementResponse
    {
        [OfxElement("CURDEF")]
        public string CurrencyName { get; set; }
        [OfxElement("BANKACCTFROM")]
        public OfxAccountInfo AccountInfo { get; set; }
        [OfxElement("BANKTRANLIST")]
        public OfxBankList BankList { get; set; }
        [OfxElement("LEDGERBAL")]
        public OfxBalance Balance { get; set; }
    }
}