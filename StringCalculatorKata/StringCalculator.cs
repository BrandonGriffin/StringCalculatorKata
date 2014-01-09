using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public Int32 Calculate(String input)
        {
            if (IsEmptyString(input))
                return 0;

            var delimiters = new String[] { "\n", "," };
            var sum = 0;
            var hasANegative = false;
            var negativesExceptionMessage = "Negatives not allowed: ";

            var strings = ChangeDelimiter(input, delimiters);
            var numbers = ConvertStringsToIntArray(strings);

            for (var i = 0; i < numbers.Length; i++)
            {
                if (IsANegativeNumber(numbers, i))
                {
                    if (hasANegative)
                        negativesExceptionMessage += ", " + numbers[i];
                    else
                        negativesExceptionMessage += numbers[i];

                    hasANegative = true;
                }

                if (NumberIsNotOver1000(numbers, i))
                    sum += numbers[i];
            }
            
            if (hasANegative)
                throw new System.NegativesNotAllowedException(negativesExceptionMessage);

            if (IsASingleNumber(numbers))
                return numbers.First();

            return sum; 
        }

        private static Boolean NumberIsNotOver1000(Int32[] numbers, Int32 i)
        {
            return numbers[i] <= 1000;
        }

        private static Boolean IsANegativeNumber(Int32[] numbers, Int32 i)
        {
            return numbers[i] < 0;
        }

        private static String[] ChangeDelimiter(String input, String[] delimiters)
        {
            if (HasANewDelimiter(input))
            {
                var delimiterString = String.Empty;
                var newDelimiter = ',';

                for (var i = 2; i < input.Length; i++)
                {
                    if (input[i] != '[')
                    {
                        if (IsTheNewDelimiter(input, i))
                            newDelimiter = input[i];

                        if (IsAMultipleCharacterDelimiter(input, newDelimiter, i))
                            delimiterString += input[i];
                        else
                            AddDelimiterToArray(ref delimiters, ref delimiterString);
                    }  
                }

                input = TrimInput(input, newDelimiter); 
            }

            return input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }

        private static void AddDelimiterToArray(ref String[] delimiters, ref String delimiterString)
        {
            Array.Resize<String>(ref delimiters, delimiters.Length + 1);
            delimiters[delimiters.Length - 1] = delimiterString;
            delimiterString = String.Empty;
        }

        private static bool IsTheNewDelimiter(String input, Int32 i)
        {
            return i == 2 || input[i - 1] == '[';
        }

        private static bool IsAMultipleCharacterDelimiter(String input, Char newDelimiter, Int32 i)
        {
            return input[i] == newDelimiter;
        }

        private static String TrimInput(String input, Char newDelimiter)
        {
            var charsToRemove = new Char[] { '/', '\n', '[', ']', input[3], newDelimiter };
            input = input.Trim(charsToRemove);
            return input;
        }

        private static Boolean IsASingleNumber(Int32[] numbers)
        {
            return numbers.Count() == 1;
        }

        private static Boolean HasANewDelimiter(String input)
        {
            return input[0] == '/';
        }

        private static Int32[] ConvertStringsToIntArray(String[] strings)
        {
            return strings.Select(x => Int32.Parse(x)).ToArray();
        }

        private static Boolean IsEmptyString(String input)
        {
            return input.Trim() == String.Empty;
        }
    }
}
