using System;
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
        public void Should_Return_3_For_III()
        {
            var expression = "III";
            var calculator = new RomanCalculator(expression);
            
            Assert.AreEqual(3, calculator.Result());    
        }

        [Test]
        public void Should_Convert_Roman_Expression_To_Integer_Expression()
        {
            var expression = "I + II + III * ( V - I )";
            var expected = "1 + 2 + 3 * ( 5 - 1 )";
            
            var calculator = new RomanCalculator(expression);
            
            Assert.AreEqual(expected, calculator.ConvertToIntegerExpression());
        }
        
        [Test]
        public void Should_Add_Two_Roman_Numbers()
        {
            var expression = "I + II";
            
            var calculator = new RomanCalculator(expression);
            
            Assert.AreEqual(3, calculator.Result());
        }
        
        [Test]
        public void Should_Subtract_Two_Roman_Numbers()
        {
            var expression = "I - II";
            
            var calculator = new RomanCalculator(expression);
            
            Assert.AreEqual(-1, calculator.Result());
        }
        
        [Test]
        public void Should_Multiply_Two_Roman_Numbers()
        {
            var expression = "I * II";
            
            var calculator = new RomanCalculator(expression);
            
            Assert.AreEqual(2, calculator.Result());
        }
        
        [Test]
        public void Should_Divide_Two_Roman_Numbers()
        {
            var expression = "I / II";
            
            var calculator = new RomanCalculator(expression);
            
            Assert.AreEqual(0.5, calculator.Result());
        }
        
        
        [Test]
        public void Should_Add_Three_Roman_Numbers()
        {
            var expression = "I + II + III";
            
            var calculator = new RomanCalculator(expression);
            
            Assert.AreEqual(6, calculator.Result());
        }
        
        [Test]
        public void Should_Subtract_Three_Roman_Numbers()
        {
            var expression = "I - II - III";
            
            var calculator = new RomanCalculator(expression);
            
            Assert.AreEqual(-4, calculator.Result());
        }
        
        [Test]
        public void Should_Multiply_Three_Roman_Numbers()
        {
            var expression = "I * II * III";
            
            var calculator = new RomanCalculator(expression);
            
            Assert.AreEqual(6, calculator.Result());
        }
        
        [Test]
        public void Should_Divide_Three_Roman_Numbers()
        {
            var expression = "I / II / III";
            
            var calculator = new RomanCalculator(expression);
            
            Assert.AreEqual(0.16666666666666666, calculator.Result());
        }

        [Test]
        public void Should_Perform_Multiplication_Before_Addition()
        {
            var multiplicationIsFirstInExpression = "I * II + III";
            
            var calculator = new RomanCalculator(multiplicationIsFirstInExpression);

           Assert.AreEqual(5, calculator.Result());
            
            var multiplicationIsSecondInExpression = "I + II * III";
            
            calculator = new RomanCalculator(multiplicationIsSecondInExpression);

            Assert.AreEqual(7, calculator.Result());
        }

        [Test]
        public void Should_Identify_Plus_Operator()
        {
            var calculator = new RomanCalculator(String.Empty);
            
            Assert.IsTrue(calculator.IsOperator("+"));
        }
        
        [Test]
        public void Should_Identify_Minus_Operator()
        {
            var calculator = new RomanCalculator(String.Empty);
            
            Assert.IsTrue(calculator.IsOperator("-"));
        }
        
        [Test]
        public void Should_Identify_Multiplication_Operator()
        {
            var calculator = new RomanCalculator(String.Empty);
            
            Assert.IsTrue(calculator.IsOperator("*"));
        }
        
        [Test]
        public void Should_Identify_Division_Operator()
        {
            var calculator = new RomanCalculator(String.Empty);
            
            Assert.IsTrue(calculator.IsOperator("/"));
        }

    }
}