using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace TipAndTrapsOne._02
{
    [TestClass]
    public class GeHasCodeDictorionaryExample
    {
        [TestMethod]
        public void BadGetHashCodeExample()
        {
            var p1 = new PersonIdBadHash { Id = 1 };
            var p2 = new PersonIdBadHash { Id = 2 };

            var d = new Dictionary<PersonIdBadHash, string>();

            d.Add(p1, "Sarah");
            d.Add(p2, "John");

            var john = d[p2];

            Trace.WriteLine(p1.Id.GetHashCode());
            Trace.WriteLine(p1.GetHashCode());

            john = d[p2];
        }

        [TestMethod]
        public void BetterGetHashCodeExample()
        {
            var p1 = new PersonalIdBetterHash(1);
            var p2 = new PersonalIdBetterHash(2);

            var d = new Dictionary<PersonalIdBetterHash, string>();

            d.Add(p1, "Sarah");
            d.Add(p2, "John");

            var john = d[p2];

            //p2.Id = 99; IDictionary is now immutable, so our hashcode cannot change now
        }
    }

    internal class PersonIdBadHash
    {
        public int Id { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    internal class PersonalIdBetterHash
    {
        public PersonalIdBetterHash(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
