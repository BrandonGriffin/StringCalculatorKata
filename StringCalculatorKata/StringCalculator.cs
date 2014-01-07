using System;
using System.Collections.Generic;
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

            try
            {
                var strings = input.Split(','); 
                var sum = 0;
                Int32[] numbers = ConvertStringsToIntArray(strings);

                for (var i = 0; i < numbers.Length; i++)
                {
                    sum += numbers[i];
                }

                return sum;
            }
            catch
            {
                return Convert.ToInt32(input.Trim());
            }            
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
