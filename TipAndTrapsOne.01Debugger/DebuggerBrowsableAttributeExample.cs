using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace TipAndTrapsOne._01Debugger
{
    [TestClass]
    public class DebuggerBrowsableAttributeExample
    {
        [TestMethod]
        public void Without()
        {
            var p = new PersonWithoutDebuggerBrowsable
            {
                AgeInYears = 50,
                Name = "Sarah",
                FaveColors = { "Red", "Green", "Blue" }
            };
        }
    }

    public class PersonWithoutDebuggerBrowsable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public int AgeInYears { get; set; }
        public string Name { get; set; }
        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public IList<string> FaveColors { get; set; }

        public PersonWithoutDebuggerBrowsable()
        {
            FaveColors = new List<string>();
        }
    }
}
