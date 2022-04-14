using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace TipAndTrapsOne._03.Tests
{
    [TestClass]
    public class LinqReEvaluationExample
    {
        [TestMethod]
        public void WithReEvaluation()
        {
            var nums = new List<int> { 1, 2, 3, 4 };

            var q = from n in nums
                    select new
                    {
                        Number = n,
                        ExecutionTime = DateTime.Now.ToString("mm:ss:ff")
                    };

            Trace.WriteLine("1st enumeration");
            foreach (var n in q)
            {
                Trace.WriteLine(n);
            }

            Thread.Sleep(2000);

            Trace.WriteLine("2nd enumeration");
            foreach (var n in q)
            {
                Trace.WriteLine(n);
            }
        }

        [TestMethod]
        public void WithoutReEvaluation()
        {
            var nums = new List<int> { 1, 2, 3, 4 };

            var q = (from n in nums
                     select new
                     {
                         Number = n,
                         ExecutionTime = DateTime.Now.ToString("mm:ss:ff")
                     }).ToList();

            Trace.WriteLine("1st enumeration");
            foreach (var n in q)
            {
                Trace.WriteLine(n);
            }
            Thread.Sleep(2000);
            Trace.WriteLine("2nd enumeration");
            foreach (var n in q)
            {
                Trace.WriteLine(n);
            }
        }
    }
}
