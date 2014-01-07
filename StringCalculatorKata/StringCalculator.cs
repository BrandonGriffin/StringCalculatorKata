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
                Int32[] numbers = strings.Select(x => Int32.Parse(x)).ToArray();
                return numbers[0] + numbers[1];
            }
            catch
            {
                return Convert.ToInt32(input.Trim());
            }            
        }
    }
}
