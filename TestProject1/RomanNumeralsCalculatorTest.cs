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
        public void TestMethod1(string romanNum1, string romanNum2, string expectedResult)
        {
            string actualResult = RomanNumeralsCalculator.add(romanNum1, romanNum2);
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
            var actualResult = RomanNumeralsCalculator.convertNumeralStringToInt(numeral);
            Assert.AreEqual(expectedResult, actualResult);
        } //As arabic numbers can be split into their constituent parts (1066 becomes 1 0 6 6),

//so too can Roman numerals, just without the zero(1066 becomes MLXVI, or M (1000) LX(60) and VI(6)).
        [TestMethod]
        [DataRow(1066, "MLXVI")]
        public void ConvertIntToStringNumeralIsCorrect(int numeral, string expectedResult)
        {
            var actualResult = RomanNumeralsCalculator.ConvertIntToNumeralStringArray(numeral);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [DataRow("IIII", "Input IIII failed. Cannot repeat more than 3 times.")]
        [DataRow("VVVV", "Input VVVV failed. Cannot repeat more than 3 times.")]
        [DataRow("XXXX", "Input XXXX failed. Cannot repeat more than 3 times.")]
        [DataRow("XIIII", "Input XIIII failed. Cannot repeat more than 3 times.")]
        public void MoreThan3ConsecutiveIdenticalNumeralsThrowsException(string numeral, string expectedExceptionMsg)
        {
            Assert.ThrowsException<ArgumentException>(() => RomanNumeralsCalculator.convertNumeralStringToInt(numeral),
                expectedExceptionMsg);
        }

        [TestMethod]
        [DataRow("VV", "Input VV failed. Cannot repeat this numeral.")]
        [DataRow("LL", "Input LL failed. Cannot repeat this numeral.")]
        [DataRow("DD", "Input DD failed. Cannot repeat this numeral.")]
        [DataRow("CDD", "Input CDD failed. Cannot repeat this numeral.")]
        public void RepeatingCertainNumeralsThrowsException(string numeral, string expectedExceptionMsg)
        {
            Assert.ThrowsException<ArgumentException>(() => RomanNumeralsCalculator.convertNumeralStringToInt(numeral),
                expectedExceptionMsg);
        }

        [TestMethod]
        [DataRow("IL", "Input IL failed. This numeral contains a subtraction higher than its next 2 highest values.")]
        [DataRow("IM", "Input IM failed. This numeral contains a subtraction higher than its next 2 highest values.")]
        [DataRow("VD", "Input VD failed. This numeral contains a subtraction higher than its next 2 highest values.")]
        [DataRow("VM", "Input VM failed. This numeral contains a subtraction higher than its next 2 highest values.")]
        [DataRow("LM", "Input LM failed. This numeral contains a subtraction higher than its next 2 highest values.")]
        public void IllegalSubtractionsThrowException(string numeral, string expectedExceptionMsg)
        {
            Assert.ThrowsException<ArgumentException>(() => RomanNumeralsCalculator.convertNumeralStringToInt(numeral),
                expectedExceptionMsg);
        }

        [TestMethod]
        [DataRow("VM", "Input VM failed.This numeral cannot be subtracted.")]
        [DataRow("LC", "Input LC failed.This numeral cannot be subtracted.")]
        [DataRow("DM", "Input DM failed.This numeral cannot be subtracted.")]
        public void IllegalNumeralPosition(string numeral, string expectedExceptionMsg)
        {
            Assert.ThrowsException<ArgumentException>(() => RomanNumeralsCalculator.convertNumeralStringToInt(numeral),
                expectedExceptionMsg);
        }

        [TestMethod]
        [DataRow("XXL", "Only one subtraction can be made per numeral.")]
        [DataRow("IXL", "Only one subtraction can be made per numeral.")]
        public void MultipleSubtractionsNotAllowed(string numeral, string expectedExceptionMsg)
        {
            Assert.ThrowsException<ArgumentException>(() => RomanNumeralsCalculator.convertNumeralStringToInt(numeral),
                expectedExceptionMsg);
        }
    }
}