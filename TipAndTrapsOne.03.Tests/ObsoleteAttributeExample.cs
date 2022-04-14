using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TipAndTrapsOne._03.Tests
{
    [TestClass]
    public class ObsoleteAttributeExample
    {
        [TestMethod]
        public void TestMethod1()
        {
            new UseAtTheClassLevel();

            new UseAtTheClassLevelWithMessage();

            var a = new UseOnIndividualMembers();
            a.Name = "Sarah";

            //new UseAtTheClassLevelWithCompilerError(); //This is going to throw an error cause is obsolete with error flag
        }

        [Obsolete]
        public class UseAtTheClassLevel
        {

        }

        [Obsolete("Use class X from now on")]
        public class UseAtTheClassLevelWithMessage
        {

        }

        public class UseOnIndividualMembers
        {
            [Obsolete("Use FullName property from now on")]
            public string Name { get; set; }
            public string FullName { get; set; }
        }
    }

    [Obsolete("this class can no logner be used", true)]
    internal class UseAtTheClassLevelWithCompilerError
    {
    }
}
