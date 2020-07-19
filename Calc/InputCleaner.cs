using System;

namespace Calc
{
    public static class InputCleaner
    {
        public static string Clean(string input)
        {
            if(string.IsNullOrEmpty(input))
                return String.Empty;
            
            var trimmedInput = input.Trim();
            return trimmedInput;
        }
    }
}