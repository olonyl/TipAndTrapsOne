using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace CompilerInferredGenericMethodtypes
{
    [TestClass]
    public class GenericMethods
    {
        [TestMethod]
        public void Example()
        {
            var dw = new DebugWriter();

            var d = DateTime.Now;
            dw.WriteToDebug(d);

            var m = new Movie();
            dw.Write(m);

            //dw.Write("test");//String is not convertible to IExtraDebuggable
        }
    }

    class DebugWriter
    {
        public void WriteToDebug<T>(T t)
        {
            Trace.WriteLine(t);
        }

        public void Write<T>(T t) where T : IExtraDebuggable
        {
            Trace.WriteLine(t.DebugInfo);
        }
    }

    internal interface IExtraDebuggable
    {
        string DebugInfo { get; }
    }

    class Movie : IExtraDebuggable
    {
        public string DebugInfo
        {
            get { return "Hi, I'm a movie"; }
        }
    }
}
