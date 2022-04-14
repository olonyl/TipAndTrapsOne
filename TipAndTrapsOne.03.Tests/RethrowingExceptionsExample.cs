using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace TipAndTrapsOne._03.Tests
{
    [TestClass]
    public class RethrowingExceptionsExample
    {
        [TestMethod]
        public void Incorrect()
        {
            var w = new ExceptionRethrowWidget();

            w.NoStacktrace();
        }

        [TestMethod]
        public void Correct()
        {
            var w = new ExceptionRethrowWidget();

            w.WithStackTrace();
        }
    }

    internal class ExceptionRethrowWidget
    {
        public ExceptionRethrowWidget()
        {
        }

        internal void NoStacktrace()
        {
            try
            {
                MethodA();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                throw ex;
            }
        }

        internal void WithStackTrace()
        {
            try
            {
                MethodA();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                throw;
            }
        }

        private void MethodA()
        {
            MethodB();
        }

        private void MethodB()
        {
            MethodC();
        }

        private void MethodC()
        {
            throw new ApplicationException("This is a demo exception.");
        }
    }
}
