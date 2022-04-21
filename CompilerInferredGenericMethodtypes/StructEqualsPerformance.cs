using CompilerInferredGenericMethodtypes.DemoSupportCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace CompilerInferredGenericMethodtypes
{
    [TestClass]
    public class StructEqualsPerformance
    {
        [TestMethod]
        public void ReferenceTypeMembersAndEqualsPerformance()
        {
            var nr1 = new NoRefNoOverride { X = 1, Y = 2 };
            var nr2 = new NoRefNoOverride { X = 1, Y = 2 };

            var wr1 = new WithRefNoOverride { X = 1, Y = 2, Description = "struct wr1" };
            var wr2 = new WithRefNoOverride { X = 1, Y = 2, Description = "struct wr2" };

            var timeWithoutReferenceMember = CalculateEqualsPerformance(nr1, nr2);
            var timeWithReferenceMember = CalculateEqualsPerformance(wr1, wr2);
        }

        [TestMethod]
        public void ReferenceTypMembersAndOverridenEquals()
        {
            var wo1 = new WithRefNoOverride { X = 1, Y = 2, Description = "struct wo1" };
            var wo2 = new WithRefNoOverride { X = 1, Y = 2, Description = "struct wo2" };

            var w1 = new WithRefWithOverride { X = 1, Y = 2, Description = "struct wo1" };
            var w2 = new WithRefWithOverride { X = 1, Y = 2, Description = "struct wo2" };

            var timeWithNoOverriddenEquals = CalculateEqualsPerformance(wo1, wo2);
            var timeWithOverriddenEquals = CalculateEqualsPerformance(w1, w2);
        }

        private long CalculateEqualsPerformance(object p1, object p2)
        {
            var sw = Stopwatch.StartNew();

            for (int i = 0; i < 10000000; i++)
            {
                p1.Equals(p2);
            }

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }

}
