using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public Int32 Calculate(String input)
        {
            if (String.IsNullOrWhiteSpace(input))
                return 0;

            var sum = 0;
            var negatives = new List<Int32>();
            
            var splitStrings = ExplodeInput(input);
            var numbers = splitStrings.Select(x => Convert.ToInt32(x));

            foreach (var n in numbers)
            {
                if (n < 0)
                    negatives.Add(n);

                if (n < 1000)
                    sum += n;
            }

            if (negatives.Any())
                ThrowsNegativeException(negatives);
            
            return sum; 
        }

        private static void ThrowsNegativeException(IEnumerable<Int32> negatives)
        {
            var negativesExceptionMessage = "Negatives not allowed: " + String.Join(", ", negatives);
            throw new NegativesNotAllowedException(negativesExceptionMessage);
        }

        private static IEnumerable<String> ExplodeInput(String input)
        {
            var delimiters = new List<String> { "\n", "," };
            if (HasANewDelimiter(input))
            {
                var delimiterString = String.Empty;
                var newDelimiter = ',';

                for (var i = 2; i < input.Length; i++)
                {
                    if (CouldBeADelimiter(input[i]))
                    {
                        if (IsTheNewDelimiter(input, i))
                            newDelimiter = input[i];

                        if (IsAMultipleCharacterDelimiter(input[i], newDelimiter))
                            delimiterString += input[i];
                        else
                        {
                            delimiters.Add(delimiterString);
                            delimiterString = String.Empty;
                        }
                    }  
                }

                input = TrimInput(input, newDelimiter); 
            }

            return input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        private static Boolean CouldBeADelimiter(Char input)
        {
            return input != '[';
        }

        private static Boolean IsTheNewDelimiter(String input, Int32 i)
        {
            return i == 2 || input[i - 1] == '[';
        }

        private static Boolean IsAMultipleCharacterDelimiter(Char input, Char newDelimiter)
        {
            return input == newDelimiter;
        }

        private static String TrimInput(String input, Char newDelimiter)
        {
            var charsToRemove = new Char[] { '/', '\n', '[', ']', input[3], newDelimiter };
            input = input.Trim(charsToRemove);
            return input;
        }

        private static Boolean HasANewDelimiter(String input)
        {
            return input.StartsWith("//");
        }
    }
}
