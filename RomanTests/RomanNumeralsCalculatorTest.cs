using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katas
{
    [TestClass]
    public class RomanNumeralsTest
    {
        [TestMethod]
        [DataRow("I", "I", "II")]
        [DataRow("V", "V", "X")]
        [DataRow("X", "X", "XX")]
        [DataRow("XX", "XX", "XL")]
        public void Add(string romanNum1, string romanNum2, string expectedResult)
        {
            var actualResult = RomanNumeralsCalculator.Add(romanNum1, romanNum2);
            Assert.AreEqual(expectedResult, actualResult);
        }
        
    }
}