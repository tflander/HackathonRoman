using System;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katas
{
    [TestClass]
    public class RomanValidationTests
    {
        [TestMethod]
        [DataRow("IIII", "Input IIII failed. Cannot repeat more than 3 times.")]
        [DataRow("VVVV", "Input VVVV failed. Cannot repeat more than 3 times.")]
        [DataRow("XXXX", "Input XXXX failed. Cannot repeat more than 3 times.")]
        [DataRow("XIIII", "Input XIIII failed. Cannot repeat more than 3 times.")]
        public void MoreThan3ConsecutiveIdenticalNumeralsThrowsException(string numeral, string expectedExceptionMsg)
        {
            Assert.ThrowsException<ArgumentException>(() => RomanStringValidator.ValidateRomanString(numeral),
                expectedExceptionMsg);
        }

        [TestMethod]
        [DataRow("VV", "Input VV failed. Cannot repeat this numeral.")]
        [DataRow("LL", "Input LL failed. Cannot repeat this numeral.")]
        [DataRow("DD", "Input DD failed. Cannot repeat this numeral.")]
        [DataRow("CDD", "Input CDD failed. Cannot repeat this numeral.")]
        public void RepeatingCertainNumeralsThrowsException(string numeral, string expectedExceptionMsg)
        {
            Assert.ThrowsException<ArgumentException>(() => RomanStringValidator.ValidateRomanString(numeral),
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
            Assert.ThrowsException<ArgumentException>(() => RomanStringValidator.ValidateRomanString(numeral),
                expectedExceptionMsg);
        }

        [TestMethod]
        [DataRow("VM", "Input VM failed.This numeral cannot be subtracted.")]
        [DataRow("LC", "Input LC failed.This numeral cannot be subtracted.")]
        [DataRow("DM", "Input DM failed.This numeral cannot be subtracted.")]
        public void IllegalNumeralPosition(string numeral, string expectedExceptionMsg)
        {
            Assert.ThrowsException<ArgumentException>(() => RomanStringValidator.ValidateRomanString(numeral),
                expectedExceptionMsg);
        }

        [TestMethod]
        [DataRow("XXL", "Only one subtraction can be made per numeral.")]
        [DataRow("IXL", "Only one subtraction can be made per numeral.")]
        public void MultipleSubtractionsNotAllowed(string numeral, string expectedExceptionMsg)
        {
            Assert.ThrowsException<ArgumentException>(() => RomanStringValidator.ValidateRomanString(numeral),
                expectedExceptionMsg);
        }        
    }
}