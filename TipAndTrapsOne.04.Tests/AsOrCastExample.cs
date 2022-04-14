using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace TipAndTrapsOne._04.Tests
{
    [TestClass]
    public class AsOrCastExample
    {
        [TestMethod]
        public void Cast()
        {
            object name = "Sarah";

            Person p = (Person)name;//Incorrect conversion

            Trace.WriteLine(p.Name);
        }

        [TestMethod]
        public void AsBad()
        {
            object name = "Sarah";

            Person p = name as Person;

            Trace.WriteLine(p.Name);//Incorrect - Null Reference Exception
        }

        [TestMethod]
        public void AsBetter()
        {
            object name = "Sarah";

            Person p = name as Person;

            if (p == null)
            {
                p = new Person { Name = "Default" };
            }

            Trace.WriteLine(p.Name);
        }
    }

    internal class Person
    {
        public string Name { get; internal set; }
    }
}
