using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CompilerInferredGenericMethodtypes
{
    [TestClass]
    public class CustomAggregate
    {
        [TestMethod]
        public void WithSeedValue()
        {
            var names = new[] { "Sarah", "Gentry", "Amrit" };

            var a = (int)names[0][0];
            var b = (int)names[1][0];
            var c = (int)names[2][0];

            var total = a + b + c;

            var rsultWithSeedZero = names.Aggregate(0,
                (runningTotal, name) => runningTotal + (int)name[0]);

            var rsultWithSeedHundred = names.Aggregate(100,
                (runningTotal, name) => runningTotal + (int)name[0]);
        }

        [TestMethod]
        public void NoSeedValue()
        {
            var numbs = new[] { 1, 2, 3, 4 };

            var resultWithSeed = numbs.Aggregate(0, CustomAccumulationFunction);
            //Since a seed value was not passed in then the first value of the sequence is used instead
            //and the aggregate starts executing from the second element
            var resultWithNoSeed = numbs.Aggregate(CustomAccumulationFunction);
        }

        private int CustomAccumulationFunction(int runningTotal, int num)
        {
            if (num % 2 == 0)
            {
                return runningTotal + num;
            }
            return runningTotal;
        }
    }
}
