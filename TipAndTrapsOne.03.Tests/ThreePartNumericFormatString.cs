using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace TipAndTrapsOne._03.Tests
{
    [TestClass]
    public class ThreePartNumericFormatString
    {
        [TestMethod]
        public void Example()
        {
            const double aPositiveNumber = 99.99;
            const double aNegativeNumber = -23.55;
            const double aZeroNumber = 0;

            const string threePartFormat = "(pos)#.##;(neg)#.##;(sorry nothing at all)";

            var positiveOutput = aPositiveNumber.ToString(threePartFormat);
            var negativeOutput = aNegativeNumber.ToString(threePartFormat);
            var zeroOutput = aZeroNumber.ToString(threePartFormat);

            Trace.IndentLevel = 10;
            Trace.WriteLine(positiveOutput);
            Trace.WriteLine(negativeOutput);
            Trace.WriteLine(zeroOutput);


        }
    }
}
