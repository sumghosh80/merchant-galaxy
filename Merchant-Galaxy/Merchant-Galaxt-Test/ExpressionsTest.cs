using System;
using Xunit;
using Merchant_Galaxy.Shared;
using Merchant_Galaxy.Roman;
using Merchant_Galaxy.Expressions;
using Merchant_Galaxy;

namespace Merchant_Galaxt_Test
{
    /// <summary>
    /// This class tests some of the expression classes that are used to identify and execute the expressions provided by the user.
    /// </summary>
    public class ExpressionsTest
    {
        [Fact]
        public void AliasExpressionTest()
        {
            AliasMapper aliasMap = new AliasMapper();
            AliasExpression expression = new AliasExpression(aliasMap);
            Assert.True(expression.Match("glob is C"));
            Assert.False(expression.Match("glob is N"));
            expression.Execute("glob is C");
            Assert.True(aliasMap.Exists("glob"));
            Assert.Equal("C", aliasMap.GetValueForAlias("glob"));
        }

        [Fact]
        public void UnitExpressionTest()
        {
            AliasMapper aliasMap = new AliasMapper();
            RomanConverter converter = new RomanConverter();
            CommodityIndex commodityIndex = new CommodityIndex();

            aliasMap.AddAlias("glob", "I");
            aliasMap.AddAlias("prok", "V");
            aliasMap.AddAlias("pish", "X");
            aliasMap.AddAlias("tegj", "L");

            ExpressionValidationHelper helper = new ExpressionValidationHelper(aliasMap, commodityIndex);
            UnitExpression expression = new UnitExpression(commodityIndex, aliasMap, converter, helper);
            expression.Execute("glob glob silver is 34 Credits");
            Assert.True(commodityIndex.Exists("silver"));
            Assert.Equal<double>(17, commodityIndex.GetPriceByCommodity("silver"));
            expression.Execute("glob prok iron is 400 Credits");
            Assert.Equal<double>(100, commodityIndex.GetPriceByCommodity("iron"));
        }

    }
}
