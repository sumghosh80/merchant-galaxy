using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant_Galaxy.Shared
{
    public interface IDecimalConverter
    {
        double? ConvertToDecimal(string input);
    }
}
