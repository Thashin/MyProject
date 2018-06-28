using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProject.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyProject.Controllers.Tests
{
    [TestClass()]
    public class ReverseWordsControllerTests
    {
        public ReverseWordsController sut;

        [TestInitialize]
        public void SetUp()
        {
            sut = new ReverseWordsController()
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [TestMethod()]
        public void GetEmptyTest()
        {
            var expected = "";
            sut.Get().TryGetContentValue(out string actual);
            Assert.AreEqual(expected,actual);
        }

        [TestMethod()]
        public void GetOneWordTest()
        {
            var expected = "staH";
            sut.Get("Hats").TryGetContentValue(out string actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetParagraphTest()
        {
            var expected = "retnE ruoy txet ot eb desrever ro desrevernu tseT.ereh yb kcilc a gnisrever noitcnuf nottub evoba ot hctaw " +
                "siht txet eb kcilC.desrever eht emas noitcnuf nottub niaga ot hctaw eht desrever txet eb esreveR'.desrevernu 'txeT lliw" +
                " esrever eht eritne txet pilF'.gnirts 'txeT lliw esrever hcae txet lufesU.enil rof gnisrever a tsil fo esreveR'.sdrow " +
                "'gnidroW lliw esrever eht eritne drow redro tuohtiw gnisrever eht drow pilF'.gnirettel 'gnidroW lliw esrever eht drow" +
                " redro fo hcae txet esreveR'.enil hcaE s'droW 'gniretteL lliw esrever hcae s'drow gnirettel tuohtiw gnignahc eht drow " +
                "redro ro edispU'.noitautcnup 'nwoD lliw etaerc eht noisulli fo na edispu nwod txet/egap aiv gnirts lasrever dna retcarahc " +
                "noitutitsbus rof srettel a ot ycavirP.z fo :ataD sihT loot si htiw-tliub dna ni-snoitcnuf tneilC ediS ,gnitpircSavaJ os ylno " +
                "ruoy retupmoc lliw ees ro ssecorp ruoy atad .tuptuo/tupni";

            sut.Get("Enter your text to be reversed or unreversed here.Test by click a reversing function button above to watch this " +
                    "text be reversed.Click the same function button again to watch the reversed text be unreversed.'Reverse Text' will" +
                    " reverse the entire text string.'Flip Text' will reverse each text line.Useful for reversing a list of words.'Reverse" +
                    " Wording' will reverse the entire word order without reversing the word lettering.'Flip Wording' will reverse the " +
                    "word order of each text line.'Reverse Each Word's Lettering' will reverse each word's lettering without changing the" +
                    " word order or punctuation.'Upside Down' will create the illusion of an upside down page/text via string reversal and" +
                    " character substitution for letters a to z.Privacy of Data: This tool is built-with and functions-in Client Side " +
                    "JavaScripting, so only your computer will see or process your data input/output.").TryGetContentValue(out string actual);

           Assert.AreEqual(expected, actual);
        }
    }
}