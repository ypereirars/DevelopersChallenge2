using Xunit;
using System.IO;
using XayahFiances.Common;
using XayahFinances.Common.Ofx.Data;
using System.Text;

namespace XayahFinances.Test
{
    public class OfxSerializerTest
    {
        readonly StreamReader _ofxFile;
        readonly OfxSerializer _ofxSerializer;

        public OfxSerializerTest()
        {
            byte[] data = Encoding.ASCII.GetBytes(@"OFXHEADER:100
                                                    DATA:OFXSGML
                                                    VERSION:102
                                                    SECURITY:NONE
                                                    ENCODING:USASCII
                                                    CHARSET:1252
                                                    COMPRESSION:NONE
                                                    OLDFILEUID:NONE
                                                    NEWFILEUID:NONE");
            var memoryStream = new MemoryStream(data);
            _ofxFile = new StreamReader(memoryStream);
            _ofxSerializer = new OfxSerializer(typeof(Ofx));
        }

        [Fact]
        public void SerializedDataShouldHaveOFXType()
        {
            var serialized = _ofxSerializer.Deserialize(_ofxFile);

            Assert.IsType<Ofx>(serialized);
        }
    }
}
