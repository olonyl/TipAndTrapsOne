using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace TipAndTrapsOne._02
{
    [TestClass]
    public class ChangingThreadCultureExample
    {
        [TestMethod]
        public void Example()
        {
            const string australiaCultureString = "en-AU";
            const string turkeyCultureString = "tr-TR";

            const double someNumber = 23.45;

            Trace.WriteLine("Setting English language - Australia country/region");

            var australiaCultureInfo = CultureInfo.GetCultureInfo(australiaCultureString);
            Thread.CurrentThread.CurrentCulture = australiaCultureInfo;

            var ausUppercasel = "i".ToUpper();
            Trace.WriteLine(ausUppercasel);
            Trace.WriteLine(someNumber);
            Trace.WriteLine(DateTime.Now);

            Trace.WriteLine("Setting Turkish language - Turkey country/region");

            var turkeyCultureInfo = CultureInfo.GetCultureInfo(turkeyCultureString);
            Thread.CurrentThread.CurrentCulture = turkeyCultureInfo;

            var turUppercasel = "i".ToUpper();

            Trace.WriteLine(turUppercasel);
            Trace.WriteLine(someNumber);
            Trace.WriteLine(DateTime.Now);

        }
    }
}
