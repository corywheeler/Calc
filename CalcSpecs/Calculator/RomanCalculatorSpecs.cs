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
        
        [Test]
        public void Should_Return_5_For_V()
        {
            var expression = "V";
            var calculator = new RomanCalculator("V");
            
            Assert.AreEqual(5, calculator.Result());
        }

        [Test]
        public void Should_Return_10_For_X()
        {
            var expression = "X";
            var calculator = new RomanCalculator(expression);
            
            Assert.AreEqual(10, calculator.Result());    
        }
        
    }
}