using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public Int32 Calculate(String input)
        {
            if (IsEmptyString(input))
                return 0;

            var delimiters = new Char[] { '\n', ',' };
            var sum = 0;
            var hasANegative = false;
            var negativesExceptionMessage = "Negatives not allowed: ";

            input = ChangeDelimiter(input, delimiters);

            var strings = input.Split(delimiters); 
            var numbers = ConvertStringsToIntArray(strings);

            if (IsASingleNumber(numbers))
                return numbers.First();

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
            
            if(hasANegative)
                throw new System.NegativesNotAllowedException(negativesExceptionMessage);
            
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

        private static String ChangeDelimiter(String input, Char[] delimiters)
        {
            if (HasANewDelimiter(input))
            {
                var charsToRemove = new Char[] { '/', '\n', input[2] };
                delimiters[1] = input[2];
                input = input.Trim(charsToRemove);
            }
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
