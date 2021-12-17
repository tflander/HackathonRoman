using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katas
{
    [TestClass]
    public class RomanToIntConverterTests
    {
        [TestMethod]
        [DataRow("I", 1)]
        [DataRow("III", 3)]
        [DataRow("V", 5)]
        [DataRow("X", 10)]
        [DataRow("II", 2)]
        [DataRow("IV", 4)]
        [DataRow("VI", 6)]
        [DataRow("XL", 40)]
        [DataRow("LX", 60)]
        [DataRow("CD", 400)]
        [DataRow("CM", 900)]
        [DataRow("MDC", 1600)]
        public void ConvertToIntIsCorrect(string numeral, int expectedResult)
        {
            var actualResult = RomanToIntConverter.ConvertRomanToInt(numeral);
            Assert.AreEqual(expectedResult, actualResult);
        } 
        
    }
}