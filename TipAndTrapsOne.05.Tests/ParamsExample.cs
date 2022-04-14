using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TipAndTrapsOne._05.Tests
{
    [TestClass]
    public class ParamsExample
    {
        [TestMethod]
        public void TestMethod1()
        {
            WriteDebug("* Some different objects *", 42, new Uri("http://pluralshight.com"), true);

            WriteDebug("* No objects *");
        }

        private void WriteDebug(string message, params object[] objects)
        {
            Trace.Write(message);

            foreach (var o in objects)
            {
                Trace.WriteLine(o);
            }
        }

        private IEnumerable<int> CalcStringLenghts(params string[] strings)
        {
            foreach (var s in strings)
            {
                yield return s.Length;
            }
        }

        [TestMethod]
        public void CalcStringLenghtsExample()
        {
            foreach (var len in CalcStringLenghts("a", "aa", "aaa"))
            {
                Trace.WriteLine(len);
            }
        }

        [TestMethod]
        public void CalcStringLengthsExampleWithArray()
        {
            var names = new[] { "Sarah", "Gentry", "Angelina" };

            foreach (var len in CalcStringLenghts(names))
            {
                Trace.WriteLine(len);
            }
        }
    }
}
