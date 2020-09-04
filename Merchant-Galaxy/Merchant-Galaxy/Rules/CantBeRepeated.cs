using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merchant_Galaxy.Shared;


namespace Merchant_Galaxy.Rules
{
    public class CantBeRepeated :IRuleOfConversion
    {
        public bool ExecuteCheck(string input)
        {
            bool result = (input.Length < 2) ||
                    (input.Count(c => c == 'D') <= 1 && input.Count(c => c == 'L') <= 1 && input.Count(c => c == 'V') <= 1);

            if (!result) { Console.WriteLine("CantBeRepeated Rule has been violated"); }

            return result;
        }
    }
}
