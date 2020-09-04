using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant_Galaxy.Shared
{
    /// <summary>
    /// This interface should be implemented by all the rules that needs to be satisfied before a conversion 
    /// from one number system to another can happen.
    /// </summary>
    public interface IRuleOfConversion
    {
        bool ExecuteCheck(string input);
    }
}
