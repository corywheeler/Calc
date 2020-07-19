using System;
using Calc.Utility;

namespace Calc
{
    public class Program    
    {
        public static void Main(string[] args)
        {
            string expression = string.Empty;

            if (args.Length > 0)
            {
                expression = InputCleaner.Clean(args[0]);
                Console.WriteLine("{0}: Roman Numeral Calculator", expression);
            }
            else
            {
                Console.WriteLine("usage: Calc I + I");
            }
        }
    }
}