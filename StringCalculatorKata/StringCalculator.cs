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
                
            if (HasANewDelimiter(input))
            {
                var charsToRemove = new Char[] { '/', '\n', input[2] };
                delimiters[1] = input[2];
                input = input.Trim(charsToRemove);
            }

            var strings = input.Split(delimiters); 
            var numbers = ConvertStringsToIntArray(strings);

            if (numbers.Count() == 1)
                return numbers.First();

            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                    throw new System.NegativesNotAllowedException("Negatives not allowed: " + numbers[i]);

                sum += numbers[i];
            }
            return sum; 
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
