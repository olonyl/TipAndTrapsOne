using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace CompilerInferredGenericMethodtypes
{
    [TestClass]
    public class StaticConstructorExceptions
    {
        [TestMethod]
        public void Example()
        {
            try
            {
                var greeting = ClassWithStaticCtorException.Greeting;
            }
            catch (Exception)
            {

                Trace.WriteLine("Static ctor exception occurred");
            }
            //This remains useless since the static constructor already threw an exception
            var c = new ClassWithStaticCtorException();
        }
    }

    internal class ClassWithStaticCtorException
    {
        public static readonly string Greeting = "Hello world";

        static ClassWithStaticCtorException()
        {
            throw new ApplicationException("Demo exception");
        }
    }
}
