using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipAndTrapsOne._01Debugger
{
    [TestClass]
    public class VirtualMethodCallFromConstrusctor
    {
        [TestMethod]
        public void UsingBaseClass()
        {
            new BaseClass();
        }

        [TestMethod]
        public void UsingDerivedClass()
        {
            new DerivedClass();
        }
    }

    internal class DerivedClass : BaseClass
    {
        protected override void InitName()
        {
            Name = null;
        }
    }

    public class BaseClass
    {
        private int _length;
        protected string Name;

        public BaseClass()
        {
            InitName();//This is not a good idea because is a virtual method

            _length = Name.Length;
        }

        protected virtual void InitName()
        {
            Name = "Sarah";
        }
    }
}
