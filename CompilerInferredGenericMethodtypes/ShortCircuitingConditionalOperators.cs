using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompilerInferredGenericMethodtypes
{
    [TestClass]
    public class ShortCircuitingConditionalOperators
    {
        [TestMethod]
        public void ShortCircuitConditionalAnd()
        {
            const string name = "Sarah";

            bool b = false && name == "Sarah";

            // Short-circuiting operator
            b = false && CheckName(name);

            // non short-circuiting operator
            b = false & CheckName(name);
        }

        private bool CheckName(string name)
        {
            return name == "Sarah";
        }
    }
}
