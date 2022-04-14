using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace TipAndTrapsOne._05.Tests
{
    [TestClass]
    public class FormattingColumnsExample
    {
        [TestMethod]
        public void TheHardWay()
        {
            const string name = "Claire";
            const int age = 30;
            const string gender = "female";

            var output = "Name: " + name.PadRight(20) +
                "Age: " + age.ToString().PadLeft(10) +
                "Gender: " + gender.PadRight(20);

            Trace.WriteLine(output);
        }

        [TestMethod]
        public void TheEasierWay()
        {
            const string name = "Claire";
            const int age = 30;
            const string gender = "female";

            var output = string.Format("Name: {0,-20}Age:{1,-10}Gender: {2,-20}",
                name, age, gender);

            Trace.WriteLine(output);

            Trace.WriteLine(string.Format("Name: {0,-20}Age:{1,10}Gender: {2,-20}",
                name, age, gender));
        }
    }
}
