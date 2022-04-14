using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TipAndTrapsOne._02
{
    [TestClass]
    public class FlagEnumExamples
    {

        [Flags]
        enum Alignments
        {
            None = 0,
            Top = 1,
            Right = 2,
            Bottom = 4,
            Left = 8
        }

        [TestMethod]
        public void Example()
        {
            // setting and evaluating
            var topRightCombination = Alignments.Top | Alignments.Right;
            var bottomLeftCombination = Alignments.Bottom | Alignments.Left;


            var isTopIncluded = (topRightCombination & Alignments.Top) != 0;
            isTopIncluded = topRightCombination.HasFlag(Alignments.Top);

            // combining combinations
            var all = topRightCombination | bottomLeftCombination;

            // toggling values
            all ^= Alignments.Top;

            all ^= Alignments.Top;
        }
    }
}
