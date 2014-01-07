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
            else
                return Convert.ToInt32(input.Trim());
        }
    }
}
