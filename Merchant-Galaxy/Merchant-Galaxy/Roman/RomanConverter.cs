using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merchant_Galaxy.Shared;

namespace Merchant_Galaxy.Roman
{
    public class RomanConverter : IDecimalConverter
    {


        List<IRuleOfConversion> toDecimalRules;
        Dictionary<string, int> romanToDecimalMapper;

        public RomanConverter()
        {
            toDecimalRules = RomanToDecimalFactory.GetRules();
            romanToDecimalMapper = new Dictionary<string, int>();
            romanToDecimalMapper.Add("I", 1);
            romanToDecimalMapper.Add("V", 5);
            romanToDecimalMapper.Add("X", 10);
            romanToDecimalMapper.Add("L", 50);
            romanToDecimalMapper.Add("C", 100);
            romanToDecimalMapper.Add("D", 500);
            romanToDecimalMapper.Add("M", 1000);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public double? ConvertToDecimal(string input)
        {
            if (!ValidateToDecimal(input)) return null;
            return CalculateDecimal(input);
        }
        /// <summary>
        /// This method validates the Roman Numeral.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        private bool ValidateToDecimal(string input)
        {
            return toDecimalRules.All(rule => { return rule.ExecuteCheck(input); });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private double CalculateDecimal(string input)
        {
            double current = 0, next = 0, total = 0;

            for (int i = 0; i < input.Length; i++)
            {
                current = romanToDecimalMapper[input[i].ToString()];
                if (i < input.Length - 1) { next = romanToDecimalMapper[input[i + 1].ToString()]; }

                if (current < next)
                {
                    total += next - current;
                    i++;
                }
                else { total += current; }
                current = next = 0;
            }

            return total;
        }
    }
}