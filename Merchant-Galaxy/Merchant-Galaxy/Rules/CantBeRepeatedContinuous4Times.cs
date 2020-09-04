using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merchant_Galaxy.Shared;   

namespace Merchant_Galaxy.Rules
{
    public class CantBeRepeatedContinuous4Times: IRuleOfConversion
    {
        /// <summary>
        /// This rules is used in the Roman to Decimal conversion and it checks for the 4 times repetition of certain Roman Numerals.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool ExecuteCheck(string input)
        {
            bool result = (input.Length < 4) || !(input.Contains("IIII") || input.Contains("XXXX") || input.Contains("CCCC") || input.Contains("MMMM"));

            if (!result) { Console.WriteLine("CantBeRepeated4Times Rule has been violated"); }

            return result;
        }
    }
}
