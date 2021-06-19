using XayahFinances.Common.Ofx.Attributes;

namespace XayahFinances.Common.Ofx.Data
{
    public class OfxStatemetResponse
    {
        [OfxElement("CURDEF")]
        public string CurrencyName { get; set; }
        [OfxElement("BANKACCTFROM")]
        public OfxAccountInfo AccountInfo { get; set; }
    }
}