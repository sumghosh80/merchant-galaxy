﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merchant_Galaxy.Shared;


namespace Merchant_Galaxy.Roman
{
    public class Roman : INumberSystem
    {
        private static string alphabet = "IVXLCDM";

        public static string GetAlphabet()
        {
            return alphabet;
        }

        public static bool IsSmaller(string first, string second)
        {
            return alphabet.IndexOf(first, StringComparison.OrdinalIgnoreCase) <
                    alphabet.IndexOf(second, StringComparison.OrdinalIgnoreCase);
        }
    }
}
