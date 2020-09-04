using System;
using Xunit;
using Merchant_Galaxy.Roman;
namespace Merchant_Galaxt_Test
{
    /// <summary>
    /// /// This class tests whether the Roman to Decimal conversion works as expected.
    /// </summary>
    public class RomanConverterTest
    {
        [Fact]
        public void ConversionTest()
        {
            RomanConverter converter = new RomanConverter();
            Assert.Equal<double>(1945,converter.ConvertToDecimal("MCMXLIVI").Value);
            Assert.Equal<double>(521, converter.ConvertToDecimal("DXXI").Value);
            Assert.Equal<double>(992,converter.ConvertToDecimal("CMXCII").Value);
            Assert.NotEqual<double>(6,converter.ConvertToDecimal("IV").Value);

        }
    }
}
