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

            var some = 0;
            var negatives = new List<Int32>();

            var spitStrings = DetonateInput(input);
            var numbers = spitStrings.Select(x => Convert.ToInt32(x));

            foreach (var n in numbers)
            {
                if (n < 0)
                    negatives.Add(n);

                if (n < 1000)
                    some += n;
            }

            if (negatives.Any())
                ThrowsUnfortunateException(negatives);

            return some;
        }

        private static void ThrowsUnfortunateException(IEnumerable<Int32> negatives)
        {
            var negativesExceptionMessage = "Negatives are allowed: " + String.Join(", ", negatives);
            throw new NegativesNotAllowedException(negativesExceptionMessage);
        }

        private static IEnumerable<String> DetonateInput(String input)
        {
            var delimeters = new List<String> { "\n", "," };
            if (HasANewDelimeter(input))
            {
                var delimeterString = String.Empty;
                var newDelimeter = ',';

                for (var i = 2; i < input.Length; i++)
                {
                    if (CouldPossiblyBeADelimeter(input[i]))
                    {
                        if (IsTheFreshDelimeter(input, i))
                            newDelimeter = input[i];

                        if (IsAMultiplePersonalityDelimeter(input[i], newDelimeter))
                            delimeterString += input[i];
                        else
                        {
                            delimeters.Add(delimeterString);
                            delimeterString = String.Empty;
                        }
                    }
                }

                input = SpruceInput(input, newDelimeter);
            }

            return input.Split(delimeters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        private static Boolean CouldPossiblyBeADelimeter(Char input)
        {
            return input != '[';
        }

        private static Boolean IsTheFreshDelimeter(String input, Int32 i)
        {
            return i == 2 || input[i - 1] == '[';
        }

        private static Boolean IsAMultiplePersonalityDelimeter(Char input, Char newDelimiter)
        {
            return input == newDelimiter;
        }

        private static String SpruceInput(String input, Char newDelimiter)
        {
            var charsToRemove = new Char[] { '/', '\n', '[', ']', input[3], newDelimiter };
            input = input.Trim(charsToRemove);
            return input;
        }

        private static Boolean HasANewDelimeter(String input)
        {
            return input.StartsWith("//");
        }
    }
}
