using System;
using Merchant_Galaxy.Shared;

namespace Merchant_Galaxy.Rules
{
    public class SingleSubtraction : IRuleOfConversion
    {
        public bool ExecuteCheck(string input)
        {
            if (input.Length < 3) return true;

            for (int i = input.Length - 1; i >= 2; i--)
            {
                if (Roman.Roman.IsSmaller(input[i - 1].ToString(), input[i].ToString()) &&
                        Roman.Roman.IsSmaller(input[i - 2].ToString(), input[i].ToString()))
                {
                    Console.WriteLine("SingleSubtraction Rule has been violated");
                    return false;
                }
            }

            return true;
        }
    }
}
