using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TipAndTrapsOne._05.Tests
{
    [TestClass]
    public class CustomFormatExample
    {
        [TestMethod]
        public void NaughtyWordCensor()
        {
            const string naughtyVersion = "He is a poopy head and darn idiot!";

            var cleanVersion = string.Format(new NaughtyWordCensorFormatProvider(),
                "Clean version: {0}",
                naughtyVersion);

            var cleanVersion2 = string.Format(new NaughtyWordCensorFormatProvider(),
                "Clean version: {0}, {1}",
                naughtyVersion,
                "some other darn string");

            var cleanVersion3 = string.Format(new NaughtyWordCensorFormatProvider(),
              "Clean version: {0:XXX}, {1}",
              naughtyVersion,
              "some other darn string");
        }
    }

    internal class NaughtyWordCensorFormatProvider : IFormatProvider, ICustomFormatter
    {
        public NaughtyWordCensorFormatProvider()
        {
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            // return CensorNaughtyWords(arg.ToString());

            if (format == "XXX")
            {
                return CensorNaughtyWords(arg.ToString());
            }
            return arg.ToString();
        }

        private string CensorNaughtyWords(string s)
        {
            return s.Replace("poopy", "p**y").Replace("darn", "d*rn");
        }

        /// <summary>
        /// Tell the caller what object provides the custom formatting functionality
        /// </summary>
        /// <param name="formatType"></param>
        /// <returns></returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }
    }
}
