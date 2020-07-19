using System;

namespace Calc.Utility
{
    public static class InputCleaner
    {
        public static string Clean(string input)
        {
            if(string.IsNullOrEmpty(input))
                return String.Empty;
            
            return RemoveAllWhiteSpace(input);
        }

        private static string RemoveAllWhiteSpace(string input)
        {
            return String.Join(" ", input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
        }
    }
}