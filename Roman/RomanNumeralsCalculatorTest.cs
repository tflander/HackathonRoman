using System;
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
            var actualResult = RomanNumeralsCalculator.ConvertRomanToInt(numeral);
            Assert.AreEqual(expectedResult, actualResult);
        } 
        
    }
}