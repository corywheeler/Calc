using System.Collections.Generic;

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
            _numeralMapping["IV"] = 4;
            _numeralMapping["V"] = 5;
            _numeralMapping["VI"] = 6;
            _numeralMapping["X"] = 10;
        }

        public double Result()
        {
            return _numeralMapping.ContainsKey(_expression) ? _numeralMapping[_expression] : 0;
        }
    }
}