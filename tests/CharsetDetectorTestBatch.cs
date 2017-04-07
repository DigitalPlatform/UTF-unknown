// CharsetDetectorTestBatch.cs created with MonoDevelop
//
// Author:
//    Rudi Pettazzi <rudi.pettazzi@gmail.com>
//    J. Verdurmen   
//

using System.IO;
using UtfUnknown.Core;
using Xunit;

namespace UtfUnknown.Tests
{

    public class CharsetDetectorTestBatch
    {
        // Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location)
        const string DATA_ROOT = "../../../Data";



        [Fact]
        public void TestLatin1()
        {
            Process(Charsets.WIN1252, "latin1");
        }

        [Fact]
        public void TestCJK()
        {
            Process(Charsets.GB18030, "gb18030"); 
            Process(Charsets.BIG5, "big5");
            Process(Charsets.SHIFT_JIS, "shiftjis");
            Process(Charsets.EUCJP, "eucjp");
            Process(Charsets.EUCKR, "euckr");
            Process(Charsets.EUCTW, "euctw");
            Process(Charsets.ISO2022_JP, "iso2022jp");
            Process(Charsets.ISO2022_KR, "iso2022kr");
        }

        [Fact]
        public void TestHebrew()
        {
            Process(Charsets.WIN1255, "windows1255");
        }

        [Fact]
        public void TestGreek()
        {
            Process(Charsets.ISO_8859_7, "iso88597");
         //todo broken   Process(Charsets.WIN1253, "windows1253");
        }

        [Fact]
        public void TestCyrillic()
        {
            Process(Charsets.WIN1251, "windows1251");
            Process(Charsets.KOI8R, "koi8r");
            Process(Charsets.IBM855, "ibm855");
            Process(Charsets.IBM866, "ibm866");
            Process(Charsets.MAC_CYRILLIC, "maccyrillic");
        }



        [Fact]
        public void TestUTF8()
        {
            Process(Charsets.UTF8, "utf8");
        }

        private static void Process(string charset, string dirname)
        {
            string path = Path.Combine(DATA_ROOT, dirname);
            var dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                Assert.True(false, $"dir {dirInfo.FullName} for {charset} is missing");
            }

            string[] files = Directory.GetFiles(path);

            if (files.Length == 0)
            {
                Assert.True(false, $"no files for charset {charset}");
            }

            foreach (string file in files)
            {


                var result = CharsetDetector.DetectFromFile(file);
                var detected = result.Detected;
                
                Assert.True(charset == detected.EncodingName, $"Charset detection failed for {file}. Expected: {charset}, detected: {detected.EncodingName} ({detected.Confidence * 100}% confidence)");

            }
        }
    }
}

