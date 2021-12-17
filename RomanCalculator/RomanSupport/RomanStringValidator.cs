using System;
using Katas;

namespace ConsoleApp1
{
    public class RomanStringValidator
    {
        public const string ValidationFailureMessage = "Cannot repeat more than 3 times.";
        public const string ValidationRepeatIllegalNumeralMessage = "Cannot repeat this numeral.";
        public const string ValidationIllegalSubtractionMessage =
            "This numeral contains a subtraction higher than its next 2 highest values.";

        public const string ValidationNumeralCannotBeSubtracted = "This numeral cannot be subtracted.";
        
        public static void ValidateRomanString(string numeral)
        {
            ValidateNumeralsForSubtraction(numeral);

            var noSubstitutionChars = "LVD";
            foreach (var noSubstitutionChar in noSubstitutionChars)
            {
                ValidateSubstitutionNumeral(numeral, noSubstitutionChar);
            }

            if (numeral.Contains("IL") ||
                numeral.Contains("IC") ||
                numeral.Contains("ID") ||
                numeral.Contains("IM") ||
                numeral.Contains("VC") ||
                numeral.Contains("VD") ||
                numeral.Contains("VM") ||
                numeral.Contains("XD") ||
                numeral.Contains("XM") ||
                numeral.Contains("LM"))
            {
                throw new ArgumentException($"Input {numeral} failed. {ValidationIllegalSubtractionMessage}");
            }

            if (numeral.Contains("VV") ||
                numeral.Contains("LL") ||
                numeral.Contains("DD"))
            {
                throw new ArgumentException($"Input {numeral} failed. {ValidationRepeatIllegalNumeralMessage}");
            }

            if (numeral.Contains("IIII") ||
                numeral.Contains("VVVV") ||
                numeral.Contains("XXXX"))
            {
                throw new ArgumentException($"Input {numeral} failed. {ValidationFailureMessage}");
            }
        }
        private static void ValidateSubstitutionNumeral(string numeral, char c)
        {
            var posOfNoSubtractChar = numeral.IndexOf(c);
            if (posOfNoSubtractChar >= 0 &&
                posOfNoSubtractChar < numeral.Length - 1)
            {
                var subtractCharValue = RomanToIntConverter.ConvertRomanCharToInt(numeral[posOfNoSubtractChar]);
                var nextCharValue = RomanToIntConverter.ConvertRomanCharToInt(numeral[posOfNoSubtractChar + 1]);

                if (nextCharValue > subtractCharValue)
                {
                    throw new ArgumentException($"Input {numeral} failed. {ValidationNumeralCannotBeSubtracted}");
                }
            }
        }

        private static void ValidateNumeralsForSubtraction(string numeral)
        {
            if (numeral.Length <= 2) return;

            for (var i = 0; i < numeral.Length - 2; i++)
            {
                var currentVal = RomanToIntConverter.ConvertRomanCharToInt(numeral[i]);

                if (currentVal < RomanToIntConverter.ConvertRomanCharToInt(numeral[i + 2]))
                {
                    throw new ArgumentException("Only one subtraction can be made per numeral.");
                }

            }
        }
    }
}