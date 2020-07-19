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
        
        [Test]
        public void Should_Return_6_For_VI()
        {
            var expression = "VI";
            var calculator = new RomanCalculator(expression);
            
            Assert.AreEqual(6, calculator.Result());    
        }
        
        [Test]
        public void Should_Return_4_For_IV()
        {
            var expression = "IV";
            var calculator = new RomanCalculator(expression);
            
            Assert.AreEqual(4, calculator.Result());    
        }
        
        [Test]
        public void Should_Return_2_For_II()
        {
            var expression = "II";
            var calculator = new RomanCalculator(expression);
            
            Assert.AreEqual(2, calculator.Result());    
        }
        
        [Test]
        public void Should_Return_0_For_Non_Roman_Numbers()
        {
            var expression = "NOT_A_ROMAN_NUMBER";
            var calculator = new RomanCalculator(expression);
            
            Assert.AreEqual(0, calculator.Result());    
        }
        
    }
}