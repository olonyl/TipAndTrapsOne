using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace TipAndTrapsOne._02
{
    [TestClass]
    public class UnicodeValidityExample
    {
        [TestMethod]
        public void Example()
        {
            var validCharacter = 'q';

            var ucCategory = char.GetUnicodeCategory(validCharacter);

            var isValidUnicode = ucCategory != UnicodeCategory.OtherNotAssigned;

            var invalidCharacter = (char)888;

            ucCategory = char.GetUnicodeCategory(invalidCharacter);

            isValidUnicode = ucCategory != UnicodeCategory.OtherNotAssigned;
        }
    }
}
