using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TipAndTrapsOne._01Debugger
{
    [TestClass]
    public class RunTimeConversionExample
    {
        [TestMethod]
        public void Example()
        {
            Type targetType;
            Type convertedType;
            object convertedValue;
            object initialValue;

            initialValue = "99";
            targetType = typeof(int);


            convertedValue = Convert.ChangeType(initialValue, targetType);
            convertedType = convertedValue.GetType();

            targetType = typeof(double);

            convertedValue = Convert.ChangeType(initialValue, targetType);
            convertedType = convertedValue.GetType();
        }
    }
}
