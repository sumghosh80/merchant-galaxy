using System;
using Xunit;
using Merchant_Galaxy.Rules;

namespace Merchant_Galaxy_Test
{
    /// <summary>
    /// /// This class tests the rules set for Roman to Decimal conversion.
    /// The symbols "I", "X", "C", and "M" can be repeated three times in succession, but no more. 
    /// (They may appear four times if the third and fourth are separated by a smaller value, such as XXXIX.) 
    /// "D", "L", and "V" can never be repeated. "I" can be subtracted from "V" and "X" only. 
    /// "X" can be subtracted from "L" and "C" only. "C" can be subtracted from "D" and "M" only. "V", "L", and 
    /// "D" can never be subtracted. Only one small-value symbol may be subtracted from any large-value symbol.
    /// </summary>
    public class RulesTest
    {
        [Fact]
        //"D", "L", and "V" can never be repeated. 
        public void CantBeRepeatedRuleTest()
        {
            CantBeRepeated rule = new CantBeRepeated();
            Assert.False(rule.ExecuteCheck("MDDCI"));
            Assert.False(rule.ExecuteCheck("MLLLDC"));
            Assert.False(rule.ExecuteCheck("MVVVCI"));
            Assert.True(rule.ExecuteCheck("MMDC"));
            Assert.True(rule.ExecuteCheck("MDCC"));

        }

        [Fact]
        //The symbols "I", "X", "C", and "M" can be repeated three times in succession, but no more. 
        /// (They may appear four times if the third and fourth are separated by a smaller value, such as XXXIX.) 
        public void CantBeRepeatedContinuous4TimesRuleTest()
        {
            CantBeRepeatedContinuous4Times rule = new CantBeRepeatedContinuous4Times();
            Assert.False(rule.ExecuteCheck("XXXX"));
            Assert.True(rule.ExecuteCheck("IXIXIXIX"));
            Assert.True(rule.ExecuteCheck("XXXIX"));
            Assert.True(rule.ExecuteCheck("CCCIX"));
        }

        [Fact]
        //"X" can be subtracted from "L" and "C" only. "C" can be subtracted from "D" and "M" only. "V", "L", and 
        /// "D" can never be subtracted.
        public void SingleSubtractionRuleTest()
        {
            SingleSubtraction rule = new SingleSubtraction();
            Assert.False(rule.ExecuteCheck("IIX"));
            Assert.False(rule.ExecuteCheck("CCM"));
            Assert.True(rule.ExecuteCheck("XXIV"));
        }

        [Fact]
        //Only one small-value symbol may be subtracted from any large-value symbol.
        public void SubtractionRuleTest()
        {
            Subtraction rule = new Subtraction();
            Assert.False(rule.ExecuteCheck("CIL"));
            Assert.False(rule.ExecuteCheck("MXD"));
            Assert.True(rule.ExecuteCheck("XIX"));
        }

    }
}
