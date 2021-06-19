using Xunit;
using System.IO;
using XayahFiances.Common;
using XayahFinances.Common.Ofx.Data;
using System;

namespace XayahFinances.Test
{
    public class OfxSerializerTest
    {
        readonly StreamReader _ofxFile;
        readonly OfxSerializer _ofxSerializer;

        public OfxSerializerTest()
        {
            _ofxFile = new StreamReader(@"..\..\..\..\..\..\OFX\extrato1.ofx");
            _ofxSerializer = new OfxSerializer(typeof(Ofx));
        }

        [Fact]
        public void SerializedDataShouldHaveOFXType()
        {
            var serialized = _ofxSerializer.Deserialize(_ofxFile);

            Assert.IsType<Ofx>(serialized);
        }

        [Fact]
        public void OFXShouldDeserializeHeaderProperly()
        {
            var ofx = (Ofx)_ofxSerializer.Deserialize(_ofxFile);

            Assert.Equal(100, ofx.OfxVersionNumber);
            Assert.Equal("OFXSGML", ofx.Data);
            Assert.Equal(102, ofx.OfxVersionBlock);
            Assert.Equal("NONE", ofx.Security);
            Assert.Equal("USASCII", ofx.Encoding);
            Assert.Equal(1252, ofx.Charset);
            Assert.Equal("NONE", ofx.Compression);
            Assert.Equal("NONE", ofx.OldFileUid);
            Assert.Equal("NONE", ofx.NewFileUid);
        }

        [Fact]
        public void OFXShouldDeserializeComplexObjectsProperly()
        {
            var ofx = (Ofx)_ofxSerializer.Deserialize(_ofxFile);

            Assert.NotNull(ofx.SignOnMessage);
            Assert.NotNull(ofx.SignOnMessage.SignOn);
            Assert.NotNull(ofx.SignOnMessage.SignOn.Status);

            Assert.Equal("POR", ofx.SignOnMessage.SignOn.Language);
            Assert.Equal(0, ofx.SignOnMessage.SignOn.Status.Code);
            Assert.Equal(new DateTimeOffset(2014, 03, 18, 10, 00, 00, new TimeSpan(-3, 0, 0)), ofx.SignOnMessage.SignOn.ServerDate);
            Assert.Equal("INFO", ofx.SignOnMessage.SignOn.Status.Severity);
        }

        [Fact]
        public void OFXShouldDeserializeBankInfoProperly()
        {
            var ofx = (Ofx)_ofxSerializer.Deserialize(_ofxFile);

            Assert.NotNull(ofx.BankMessage);
            Assert.NotNull(ofx.BankMessage.ResponseTranscation);
            Assert.NotNull(ofx.BankMessage.ResponseTranscation.Response);
            Assert.NotNull(ofx.BankMessage.ResponseTranscation.Status);
            Assert.NotNull(ofx.BankMessage.ResponseTranscation.Response.AccountInfo);
        }
    }
}
