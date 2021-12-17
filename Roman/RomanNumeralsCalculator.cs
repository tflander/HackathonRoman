using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Katas
{
    /*
     * Three responsibilities:
     *   - Addition
     *   - Conversion
     *   - Validation
     */
    public static class RomanNumeralsCalculator
    {
        public const string ValidationFailureMessage = "Cannot repeat more than 3 times.";
        public const string ValidationRepeatIllegalNumeralMessage = "Cannot repeat this numeral.";
        public const string ValidationIllegalSubtractionMessage =
            "This numeral contains a subtraction higher than its next 2 highest values.";

        public const string ValidationNumeralCannotBeSubtracted = "This numeral cannot be subtracted.";

        public static string Add(string numeral1, string numeral2)
        {
            var arabicResult = ConvertNumeralStringToInt(numeral1) + ConvertNumeralStringToInt(numeral2);
            return IntToRomanConverter.ConvertIntToRoman(arabicResult);
        }

        private static int ConvertNumeralCharToInt(char numeral)
        {
            return numeral switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => throw new ArgumentException()
            };
        }

        public static int ConvertNumeralStringToInt(string numeral)
        {
            ValidateNumeral(numeral);

            var arabicValue = 0;
            var numeralCharArr = numeral.ToCharArray();
            for (var index = 0; index < numeralCharArr.Length; index++)
            {
                var c = numeralCharArr[index];
                var currentValue = ConvertNumeralCharToInt(c);
                var nextValue = index + 1 > numeralCharArr.Length - 1
                    ? 0
                    : ConvertNumeralCharToInt(numeralCharArr[index + 1]);

                if (currentValue < nextValue)
                {
                    arabicValue -= currentValue;
                }
                else
                {
                    arabicValue += currentValue;
                }

            }

            return arabicValue;
        }
        
        public static void ValidateNumeral(string numeral)
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
                var subtractCharValue = ConvertNumeralCharToInt(numeral[posOfNoSubtractChar]);
                var nextCharValue = ConvertNumeralCharToInt(numeral[posOfNoSubtractChar + 1]);

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
                var currentVal = ConvertNumeralCharToInt(numeral[i]);

                if (currentVal < ConvertNumeralCharToInt(numeral[i + 2]))
                {
                    throw new ArgumentException("Only one subtraction can be made per numeral.");
                }

            }
        }
    }
}

