using Calc;
using NUnit.Framework;

namespace CalcSpecs
{
    [TestFixture]
    public class InputCleanerSpecs
    {
        [Test]
        public void Should_Remove_WhiteSpace_From_The_Ends()
        {
            var input = "   I    +    I    ";
            var expected = "I    +    I";
            
            Assert.AreEqual(expected, InputCleaner.Clean(input));
        }
    }
}