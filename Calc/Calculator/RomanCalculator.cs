using System.Collections.Generic;
using System.Globalization;

namespace Calc.Calculator
{
    public class RomanCalculator
    {
        private readonly string _expression;
        private Dictionary<string, double> _numeralMapping = new Dictionary<string, double>();

        public RomanCalculator(string expression)
        {
            _expression = expression;
            InitializeNumeralMapping();

        }

        private void InitializeNumeralMapping()
        {
            _numeralMapping["I"] = 1;
            _numeralMapping["II"] = 2;
            _numeralMapping["III"] = 3;
            _numeralMapping["IV"] = 4;
            _numeralMapping["V"] = 5;
            _numeralMapping["VI"] = 6;
            _numeralMapping["X"] = 10;
        }

        public double Result()
        {
            return _numeralMapping.ContainsKey(_expression) ? _numeralMapping[_expression] : Calculate();
        }

        private double Calculate()
        {
            var parts = ConvertToIntegerExpression().Split(' ');
            
            Stack<int> numbers = new Stack<int>();
            Stack<string> operators = new Stack<string>();
            
            foreach (var part in parts)
            {
                // Check if the term is an integer and add it to the integers stack
                int number = 0;
                if (int.TryParse(part, out number))
                {
                    numbers.Push(number);
                }

                // Check if the term is an operator and add it to the operators stack
                if (IsOperator(part))
                {
                    operators.Push(part);
                }
                
            }

            // Pull of the top operator in the operators stack and apply it's operation on the top two numbers
            // from the numbers stack.
            int firstOperand;
            int secondOperand;
            switch (operators.Pop())
            {
                case "+":
                    secondOperand = numbers.Pop();
                    firstOperand = numbers.Pop();
                    return firstOperand + secondOperand;
                case "-":
                    secondOperand = numbers.Pop();
                    firstOperand = numbers.Pop();
                    return firstOperand - secondOperand;
                default:
                    return 0;
            }
        }

        public string ConvertToIntegerExpression()
        {
            string newExpression = string.Empty;
            var terms = _expression.Split(' ');
            
            foreach (var term in terms)
            {
                if (_numeralMapping.ContainsKey(term))
                    newExpression += _numeralMapping[term].ToString(CultureInfo.InvariantCulture) + " ";
                else
                {
                    newExpression += term + " ";
                }
            }
            
            return newExpression.Trim();
        }

        // Will tell you if a value is an operator
        public bool IsOperator(string potentialOperator)
        {
            return potentialOperator.Equals("+") || 
                   potentialOperator.Equals("-") ||
                   potentialOperator.Equals("*");
        }
    }
}