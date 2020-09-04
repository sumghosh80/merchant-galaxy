using Merchant_Galaxy.Rules;
using Merchant_Galaxy.Shared;
using Merchant_Galaxy.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Merchant_Galaxy.Roman
{
    public class RomanToDecimalFactory
    {
        public static List<IRuleOfConversion> GetRules()
        {
            List<IRuleOfConversion> rules = new List<IRuleOfConversion>();
            rules.Add(new CantBeRepeated());
            rules.Add(new CantBeRepeatedContinuous4Times());
            rules.Add(new SingleSubtraction());
            rules.Add(new Subtraction());

            return rules;
        }

        public static List<IExpression> GetExpressions(AliasMapper aliasMap, IDecimalConverter converter, CommodityIndex commodityIndex, ExpressionValidationHelper helper)
        {
            List<IExpression> expressions = new List<IExpression>();
            expressions.Add(new AliasExpression(aliasMap));
            expressions.Add(new UnitExpression(commodityIndex, aliasMap, converter, helper));
            expressions.Add(new AliasQuestionExpression(aliasMap, converter, helper));
            expressions.Add(new UnitQuestionExpression(commodityIndex, aliasMap, converter, helper));
            expressions.Add(new  CommodityConversionExpression(commodityIndex, aliasMap, converter, helper));

            return expressions;
        }
    }
}
