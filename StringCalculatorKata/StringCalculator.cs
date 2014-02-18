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
            
            var splitStrings = Explode(input);
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

        private void ThrowsNegativeException(IEnumerable<Int32> negatives)
        {
            var negativesExceptionMessage = "Negatives not allowed: " + String.Join(", ", negatives);
            throw new NegativesNotAllowedException(negativesExceptionMessage);
        }

        private IEnumerable<String> Explode(String input)
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
                            delimiterString = AddNewDelimiter(delimiters, delimiterString);
                    }  
                }

                input = TrimInput(input, newDelimiter); 
            }

            return input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        private String AddNewDelimiter(List<String> delimiters, String delimiterString)
        {
            delimiters.Add(delimiterString);
            delimiterString = String.Empty;
            return delimiterString;
        }

        private Boolean CouldBeADelimiter(Char input)
        {
            return input != '[';
        }

        private Boolean IsTheNewDelimiter(String input, Int32 i)
        {
            return i == 2 || input[i - 1] == '[';
        }

        private Boolean IsAMultipleCharacterDelimiter(Char input, Char newDelimiter)
        {
            return input == newDelimiter;
        }

        private String TrimInput(String input, Char newDelimiter)
        {
            var charsToRemove = new Char[] { '/', '\n', '[', ']', input[3], newDelimiter };
            input = input.Trim(charsToRemove);
            return input;
        }

        private Boolean HasANewDelimiter(String input)
        {
            return input.StartsWith("//");
        }
    }
}
