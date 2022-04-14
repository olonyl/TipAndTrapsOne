using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace TipAndTrapsOne._04.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Car("Blue");

            Trace.WriteLine(c);
        }
    }

    public class Car
    {
        private readonly string _color;
        private readonly int _numberOfWheels;

        public Car(string color, int numberOfWheels = 4)
        {
            _color = color;
            _numberOfWheels = numberOfWheels;
        }

        public override string ToString()
        {
            return string.Format("Color:{0} Wheels:{1}", _color, _numberOfWheels);
        }
    }
}
