namespace Calc
{
    public static class InputCleaner
    {
        public static string Clean(string input)
        {
            var trimmedInput = input.Trim();
            return trimmedInput;
        }
    }
}