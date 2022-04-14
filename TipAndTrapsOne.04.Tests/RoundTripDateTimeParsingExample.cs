using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace TipAndTrapsOne._04.Tests
{
    [TestClass]
    public class RoundTripDateTimeParsingExample
    {
        [TestMethod]
        public void DateTimeExampleWithTimeZone()
        {
            var original = new DateTime(2000, 12, 1, 13, 30, 0, DateTimeKind.Local);

            var safeRoundTripString = original.ToString("o");

            var reparsed = DateTime.Parse(safeRoundTripString);

            Trace.WriteLine(original);
            Trace.WriteLine(safeRoundTripString);
            Trace.WriteLine(reparsed);
        }

        [TestMethod]
        public void DateTimeExampleEnforcingRoundTripFormat()
        {
            string almostIso8601 = "2000/12/01T13:30:00.0000000+08:00";

            var reparse = DateTime.Parse(almostIso8601);

            reparse = DateTime.ParseExact(almostIso8601, "o", null);//It's not going to work, not Round-Trip date/time pattern
        }

        [TestMethod]
        public void DateTimeOffsetExample()
        {
            var original = new DateTimeOffset(2000, 12, 1, 13, 30, 0,
                TimeSpan.FromHours(-8));

            var safeRoundTripString = original.ToString("o");

            var reparsed = DateTimeOffset.Parse(safeRoundTripString);

            Trace.WriteLine(original);
            Trace.WriteLine(safeRoundTripString);
            Trace.WriteLine(reparsed);
        }

        [TestMethod]
        public void UsefulDateTimeStyles()
        {
            DateTime d1 = DateTime.Parse("01/12/2000",
                null,
                System.Globalization.DateTimeStyles.AssumeUniversal);

            DateTime d2 = DateTime.Parse("01/12/2000",
               null,
               System.Globalization.DateTimeStyles.AssumeLocal);

            DateTime d3 = DateTime.Parse("13:30:00",
               null,
               System.Globalization.DateTimeStyles.NoCurrentDateDefault);

            DateTime d4 = DateTime.Parse("13:30:00",
               null,
               System.Globalization.DateTimeStyles.None);

        }
    }
}
