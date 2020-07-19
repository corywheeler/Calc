using Calc.Calculator;
using NUnit.Framework;

namespace CalcSpecs.Calculator
{
    [TestFixture]
    public class RomanCalculatorSpecs
    {

        [Test]
        public void Should_Return_1_For_I()
        {
            var expression = "I";
            var calculator = new RomanCalculator("I");
            
            Assert.AreEqual(1, calculator.Result());
        }
        
    }
}