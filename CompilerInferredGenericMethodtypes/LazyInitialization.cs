using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace CompilerInferredGenericMethodtypes
{
    [TestClass]
    public class LazyInitialization
    {
        [TestMethod]
        public void Example()
        {
            var nonLazyReport = new Report();

            var lazyReport = new Lazy<Report>();

            lazyReport.Value.DoSomething();
        }

        [TestMethod]
        public void SomeObjectsMightNotBeUsed()
        {
            var nonLazyReports = new Report[10];

            var sw = Stopwatch.StartNew();

            for (int i = 0; i < 10; i++)
            {
                nonLazyReports[i] = new Report();

                if (i % 2 == 0)
                {
                    nonLazyReports[i].DoSomething();
                }
            }

            sw.Stop();

            var nonLazyTotalCreationTime = sw.ElapsedMilliseconds;

            var lazyReports = new Lazy<Report>[10];

            sw = Stopwatch.StartNew();

            for (int i = 0; i < 10; i++)
            {
                lazyReports[i] = new Lazy<Report>();

                if (i % 2 == 0)
                {
                    lazyReports[i].Value.DoSomething();
                }
            }

            sw.Stop();

            var lazyTotalCreationTime = sw.ElapsedMilliseconds;
        }

        [TestMethod]
        public void Init()
        {
            var defaultCtor = new Lazy<Report>();
            var defaultRepName = defaultCtor.Value.ReportName;

            var specificCtor = new Lazy<Report>(() => new Report("Sales Report"));
            var specificRepName = specificCtor.Value.ReportName;
        }

        [TestMethod]
        public void valueIsReadOnly()
        {
            var r = new Lazy<Report>();

            //r.Value = new Report(); //.Value has not setter

            r.Value.ReportName = "Sales Report";
        }

        [TestMethod]
        public void NoExceptionCaching()
        {
            var r = new Lazy<ExceptionReport>();

            try
            {
                r.Value.DoSomething();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            try
            {
                r.Value.DoSomething();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
        }

        [TestMethod]
        public void WithExceptionCaching()
        {
            //Using Lazy overload function enables caching
            var r = new Lazy<ExceptionReport>(() => new ExceptionReport());

            try
            {
                r.Value.DoSomething();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            try
            {
                r.Value.DoSomething();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
        }
    }

    internal class ExceptionReport
    {
        public ExceptionReport()
        {
            System.Diagnostics.Trace.WriteLine("**************** Creating Exception Report ****************");

            throw new ApplicationException("Ex time: " + DateTime.Now.ToLongDateString());
        }
        internal void DoSomething()
        {

        }
    }

    internal class Report
    {
        public Report()
        {
            Trace.WriteLine("********* Creating report (default ctor) *********");

            ReportName = "Default";

            System.Threading.Thread.Sleep(1000);

        }

        public Report(string reportName)
        {
            Trace.WriteLine("********* Creating report (reportName ctor) *********");

            ReportName = reportName;

            System.Threading.Thread.Sleep(1000);
        }

        public string ReportName { get; set; }

        internal void DoSomething()
        {
            Trace.WriteLine("Doing something...");
        }
    }
}
