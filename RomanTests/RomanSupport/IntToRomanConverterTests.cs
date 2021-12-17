using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katas
{
    [TestClass]
    public class IntToRomanConverterTests
    {
        [TestMethod]
        [DataRow(1066, "MLXVI")]
        public void ConvertIntToStringNumeralIsCorrect(int numeral, string expectedResult)
        {
            var actualResult = IntToRomanConverter.ConvertIntToRoman(numeral);
            Assert.AreEqual(expectedResult, actualResult);
        }
        
    }
}