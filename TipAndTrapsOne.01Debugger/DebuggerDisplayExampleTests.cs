using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace TipAndTrapsOne._01Debugger.Tests
{
    [TestClass]
    public class DebuggerDisplayExampleTests
    {
        [TestMethod]
        public void Witout()
        {
            var p = new PersonWithoutDebuggerDisplay
            {
                AgeInYears = 50,
                Name = "Sarah"
            };
        }

        [TestMethod]
        public void With()
        {
            var p = new PersonWithDebuggerDisplay
            {
                AgeInYears = 50,
                Name = "Sarah"
            };

            var x = p.AgeInYears;
        }
    }

    public class PersonWithoutDebuggerDisplay
    {
        public int AgeInYears { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return "This is overridden ToString()";
        }
    }
    [DebuggerDisplay("This person is called {Name} and is {AgeInYears} years old")]
    public class PersonWithDebuggerDisplay
    {
        [DebuggerDisplay("{AgeInYears} years old")]
        public int AgeInYears { get; set; }
        public string Name { get; set; }
    }


}
