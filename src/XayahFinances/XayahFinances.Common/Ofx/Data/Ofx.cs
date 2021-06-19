namespace XayahFinances.Common.Ofx.Data
{
    using Attributes;


    [OfxRoot("OFX")]
    public class Ofx
    {
        [OfxElement("OFXHEADER")]
        public int OfxVersionNumber { get; set; }
        [OfxElement("DATA")]
        public string Data { get; set; }
        [OfxElement("VERSION")]
        public int OfxVersionBlock { get; set; }
        [OfxElement("SECURITY")]
        public string Security { get; set; }
        [OfxElement("ENCODING")]
        public string Encoding { get; set; }
        [OfxElement("CHARSET")]
        public int Charset { get; set; }
        [OfxElement("COMPRESSION")]
        public string Compression { get; set; }
        [OfxElement("OLDFILEUID")]
        public string OldFileUid { get; set; }
        [OfxElement("NEWFILEUID")]
        public string NewFileUid { get; set; }
        [OfxElement("SIGNONMSGSRSV1")]
        public OfxSignOnMessage SignOnMessage { get; set; }
        [OfxElement("BANKMSGSRSV1")]
        public OfxBankMessage BankMessage { get; set; }
    }
}
