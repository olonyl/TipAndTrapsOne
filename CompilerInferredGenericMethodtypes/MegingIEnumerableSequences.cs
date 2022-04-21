using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CompilerInferredGenericMethodtypes
{
    [TestClass]
    public class MegingIEnumerableSequences
    {
        [TestMethod]
        public void EqualLenghtSequences()
        {
            var names = new[] { "Sarah", "Gentry", "Amrit" };

            var ages = new[] { 20, 22, 36 };

            var namesAndAges = names.Zip(ages, CombineNameAndAge).ToList();

        }

        [TestMethod]
        public void DifferentLengthSequences()
        {
            var names = new[] { "Sarah", "Gentry", "Amrit", "Mark" };

            var ages = new[] { 20, 22, 36 };

            var namesAndAges = names.Zip(ages, (name, age) => name + " :" + age);
        }

        [TestMethod]
        public void CreatingObjects()
        {
            var names = new[] { "Sarah", "Gentry", "Amrit" };

            var ages = new[] { 20, 22, 36 };

            var namesAndAges = names.Zip(ages, (name, age) => Tuple.Create(name, age));

            //Using method group:
            namesAndAges = names.Zip(ages, Tuple.Create);
        }


        private string CombineNameAndAge(string name, int age)
        {
            return name + ": " + age;
        }
    }
}
