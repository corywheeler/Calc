using System;
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
        
        private double Calculate()
        {
            var parts = ConvertToIntegerExpression().Split(' ');
            
            Stack<double> numbers = new Stack<double>();
            Stack<string> operators = new Stack<string>();
            bool processNext = false;
            bool waitToProcess = false;
            
            for (int i = 0; i < parts.Length; i++)
            {
                var part = parts[i];
                
                // Check if the term is an integer and add it to the integers stack
                int number = 0;
                if (int.TryParse(part, out number))
                {
                    numbers.Push(number);

                    // Peek ahead to see if the next item should be processed prior to the current one.
                    if (i != parts.Length - 1 && operators.Count > 0 && Precedence(parts[i + 1]) > Precedence(operators.Peek()))
                    {
                        waitToProcess = true;
                    }
                }

                // Check if the term is an operator and add it to the operators stack
                if (IsOperator(part))
                {
                    // If the current operator has a higher precedence than the top operator ont the stack, process it next.
                    if (operators.Count >= 1 && Precedence(part) > Precedence(operators.Peek()))
                    {
                        processNext = true;
                        operators.Push(part);
                        continue;
                    }
                    
                    operators.Push(part);
                    
                }

                if (processNext)
                {
                    numbers.Push(PerformOperation(numbers, operators));
                    waitToProcess = false;
                    processNext = false;
                }
                
                if(numbers.Count == 2 && !waitToProcess)
                    numbers.Push(PerformOperation(numbers, operators));
                
            }

            return Math.Truncate(1000 * numbers.Pop()) / 1000;

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
            return  potentialOperator.IndexOfAny(new char[] {'+', '-', '*', '/'}) >= 0;
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
        
        private int Precedence(string check)
        {
            switch (check)
            {
                case "*":
                    return 2;
                case "/":
                    return 2;
                case "+":
                    return 1;
                case "-":
                    return 1;
                default:
                    return -1;
            }
        }
        
        private double PerformOperation(Stack<double> numbers, Stack<string> operators)
        {
            // Pull of the top operator in the operators stack and apply it's operation on the top two numbers
            // from the numbers stack.
            double firstOperand;
            double secondOperand;
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
                case "*":
                    secondOperand = numbers.Pop();
                    firstOperand = numbers.Pop();
                    return firstOperand * secondOperand;
                case "/":
                    secondOperand = numbers.Pop();
                    firstOperand = numbers.Pop();
                    return firstOperand / secondOperand;
                default:
                    return 0;
            }
        }
        
        public double Result()
        {
            return _numeralMapping.ContainsKey(_expression) ? _numeralMapping[_expression] : Calculate();
        }
    }
}