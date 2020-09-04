using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merchant_Galaxy.Shared;

namespace Merchant_Galaxy.Rules
{
    public class Subtraction : IRuleOfConversion
    {
        public bool ExecuteCheck(string input)
        {
            bool result = (input.Length < 2) ||
                    !(input.Contains("IL") || input.Contains("IC") || input.Contains("ID") || input.Contains("IM") ||
                    input.Contains("XD") || input.Contains("XM"));

            if (!result) { Console.WriteLine("Subtraction Rule has been violated"); }

            return result;
        }
    }
}
