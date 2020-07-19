using Calc;
using NUnit.Framework;

namespace CalcSpecs
{
    [TestFixture]
    public class InputCleanerSpecs
    {
        [Test]
        public void Should_Remove_AllWhiteSpace()
        {
            var input = "   I    +    I    ";
            var expected = "I + I";
            
            Assert.AreEqual(expected, InputCleaner.Clean(input));
        }

        [Test]
        public void Passing_Null_Gives_Empty_String()
        {
            string input = null;
            var expected = string.Empty;
            
            Assert.AreEqual(expected, InputCleaner.Clean(input));
        }
    }
}