// CharsetDetectorTest.cs created with MonoDevelop
//
// Author:
//   Rudi Pettazzi <rudi.pettazzi@gmail.com>
//

#region

using System.IO;
using System.Text;
using UtfUnknown.Core;
using NUnit.Framework;

#endregion

namespace UtfUnknown.Tests
{
    public class CharsetDetectorTest
    {
        [Test]
        public void TestAscii()
        {
            string s =
                "The Documentation of the libraries is not complete " +
                "and your contributions would be greatly appreciated " +
                "the documentation you want to contribute to and " +
                "click on the [Edit] link to start writing";
            using (MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(s)))
            {
                var result = CharsetDetector.DetectFromStream(ms);
                Assert.AreEqual(Charsets.ASCII, result.Detected.EncodingName);
                Assert.AreEqual(1.0f, result.Detected.Confidence);
            }
        }

        [Test]
        public void TestUTF8_1()
        {
            string s = "ウィキペディアはオープンコンテントの百科事典です。基本方針に賛同し" +
                       "ていただけるなら、誰でも記事を編集したり新しく作成したりできます。" +
                       "ガイドブックを読んでから、サンドボックスで練習してみましょう。質問は" +
                       "利用案内でどうぞ。";
            byte[] buf = Encoding.UTF8.GetBytes(s);
            var result = CharsetDetector.DetectFromBytes(buf);
            Assert.AreEqual("UTF-8", result.Detected.EncodingName);
            Assert.AreEqual(1.0f, result.Detected.Confidence);
        }

        [Test]
        public void TestBomUtf8()
        {
            byte[] buf = { 0xEF, 0xBB, 0xBF, 0x68, 0x65, 0x6C, 0x6C, 0x6F, 0x21 };
            var result = CharsetDetector.DetectFromBytes(buf);
            Assert.AreEqual("UTF-8", result.Detected.EncodingName);
            Assert.AreEqual(1.0f, result.Detected.Confidence);
        }

        [Test]
        public void TestBomUTF16_BE()
        {
            byte[] buf = { 0xFE, 0xFF, 0x00, 0x68, 0x00, 0x65 };

            var result = CharsetDetector.DetectFromBytes(buf);
            Assert.AreEqual(Charsets.UTF16_BE, result.Detected.EncodingName);
            Assert.AreEqual(1.0f, result.Detected.Confidence);
        }

        [Test]
        public void TestBomX_ISO_10646_UCS_4_3412()
        {
            
            byte[] buf = { 0xFE, 0xFF, 0x00, 0x00, 0x65 };
            
            var result = CharsetDetector.DetectFromBytes(buf);
            Assert.AreEqual("X-ISO-10646-UCS-4-3412", result.Detected.EncodingName);
            Assert.AreEqual(1.0f, result.Detected.Confidence);
        }

        [Test]
        public void TestBomX_ISO_10646_UCS_4_2143()
        {
            
            byte[] buf = { 0x00, 0x00, 0xFF, 0xFE, 0x00, 0x65 };
            
            var result = CharsetDetector.DetectFromBytes(buf);
            Assert.AreEqual("X-ISO-10646-UCS-4-2143", result.Detected.EncodingName);
            Assert.AreEqual(1.0f, result.Detected.Confidence);
        }

        [Test]
        public void TestBomUTF16_LE()
        {
            byte[] buf = { 0xFF, 0xFE, 0x68, 0x00, 0x65, 0x00 };
            var result = CharsetDetector.DetectFromBytes(buf);
            Assert.AreEqual(Charsets.UTF16_LE, result.Detected.EncodingName);
            Assert.AreEqual(1.0f, result.Detected.Confidence);
        }

        [Test]
        public void TestBomUTF32_BE()
        {
            byte[] buf = { 0x00, 0x00, 0xFE, 0xFF, 0x00, 0x00, 0x00, 0x68 };
            var result = CharsetDetector.DetectFromBytes(buf);
            Assert.AreEqual(Charsets.UTF32_BE, result.Detected.EncodingName);
            Assert.AreEqual(1.0f, result.Detected.Confidence);
        }

        [Test]
        public void TestBomUTF32_LE()
        {
            byte[] buf = { 0xFF, 0xFE, 0x00, 0x00, 0x68, 0x00, 0x00, 0x00 };
            var result = CharsetDetector.DetectFromBytes(buf);
            Assert.AreEqual(Charsets.UTF32_LE, result.Detected.EncodingName);
            Assert.AreEqual(1.0f, result.Detected.Confidence);
        }

        [Test]
        public void TestIssue3()
        {
            byte[] buf = Encoding.UTF8.GetBytes("3");
            var result = CharsetDetector.DetectFromBytes(buf);
            Assert.AreEqual(Charsets.ASCII, result.Detected.EncodingName);
            Assert.AreEqual(1.0f, result.Detected.Confidence);
        }

        [Test]
        public void TestOutOfRange()
        {
            
            byte[] buf = Encoding.UTF8.GetBytes("3");
            var result = CharsetDetector.DetectFromBytes(buf);
            Assert.AreEqual(Charsets.ASCII, result.Detected.EncodingName);
            Assert.AreEqual(1.0f, result.Detected.Confidence);
        }

        [Test]
        public void TestOutOfRange2()
        {
            
            byte[] buf = Encoding.UTF8.GetBytes("1234567890");
            var result = CharsetDetector.DetectFromBytes(buf);
            Assert.AreEqual(Charsets.ASCII, result.Detected.EncodingName);
            Assert.AreEqual(1.0f, result.Detected.Confidence);
        }

        [Test]
        public void TestSingleChar()
        {
            byte[] buf = Encoding.UTF8.GetBytes("3");
            var result = CharsetDetector.DetectFromBytes(buf);
            Assert.AreEqual(Charsets.ASCII, result.Detected.EncodingName);
            Assert.AreEqual(1, result.Detected.Confidence);
        }





    }
}