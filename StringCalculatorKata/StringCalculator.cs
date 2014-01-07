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
            if (input.Trim() == "")
                return 0;

            try
            {
                var strings = input.Split(',');
                int[] numbers = strings.Select(x => int.Parse(x)).ToArray();
                return numbers[0] + numbers[1];
            }
            catch
            {
                return Convert.ToInt32(input.Trim());
            }            
        }
    }
}
