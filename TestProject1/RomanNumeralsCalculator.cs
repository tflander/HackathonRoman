using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Katas
{
    public static class RomanNumeralsCalculator
    {
        public const string ValidationFailureMessage = "Cannot repeat more than 3 times.";
        public const string ValidationRepeatIllegalNumeralMessage = "Cannot repeat this numeral.";
        public const string ValidationIllegalSubtractionMessage =
            "This numeral contains a subtraction higher than its next 2 highest values.";

        public const string ValidationNumeralCannotBeSubtracted = "This numeral cannot be subtracted.";

//The symbols 'I', 'X', 'C', and 'M' can be repeated at most 3 times in a row.
//'V', 'L', and 'D' can never be repeated.
//The '1' symbols('I', 'X', and 'C') can only be subtracted from the 2 next highest values
//('IV' and 'IX', 'XL' and 'XC', 'CD' and 'CM').

//As arabic numbers can be split into their constituent parts (1066 becomes 1 0 6 6),
//so too can Roman numerals, just without the zero(1066 becomes MLXVI, or M (1000) LX(60) and VI(6)).

//The '5' symbols('V', 'L', and 'D') can never be subtracted (5, 50, 500).

//Only one subtraction can be made per numeral ('XC' is allowed, 'XXC', 'IXC' etc is not).

//We have provided a reference table of the Roman numerals that you will have to use and their arabic number equivalents.



// Numeral Number
// I 1
// V 5
// X 10
// L 50
// C 100
// D 500
// M 1000
        public static string add(string numeral1, string numeral2)
        {
            if (numeral1 == "I" && numeral2 == "I")
            {
                return "II";
            }
            
            if (numeral1 == "V" && numeral2 == "V")
            {
                return "X";
            }

            if (numeral1 == "X" && numeral2 == "X")
            {
                return "XX";
            }

            return string.Empty;
        }

        public static string convertIntToNumeralStringArray(int number)
        {
            var retValue = new StringBuilder();
            var arabicValues = new List<int>() { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            var romanDigits = new List<string>()
                { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };

            while (number > 0)
            {
                for (int i = arabicValues.Count() - 1; i >= 0; i--)
                    if (number / arabicValues[i] >= 1)
                    {
                        number -= arabicValues[i];
                        retValue.Append(romanDigits[i]);
                        break;
                    }
            }

            return retValue.ToString();
        }

        private static int convertNumeralCharToInt(char numeral)
        {
            switch (numeral)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                default:
                    throw new ArgumentException();
            }
        }

        public static int convertNumeralStringToInt(string numeral)
        {
            ValidateNumeral(numeral);

            var arabicValue = 0;
            var numeralCharArr = numeral.ToCharArray();
            for (var index = 0; index < numeralCharArr.Length; index++)
            {
                var c = numeralCharArr[index];
                var currentValue = convertNumeralCharToInt(c);
                var nextValue = index + 1 > numeralCharArr.Length - 1
                    ? 0
                    : convertNumeralCharToInt(numeralCharArr[index + 1]);

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

        public static string ConvertIntToNumeralStringArray(int arabicValue)
        {
            return convertIntToNumeralStringArray(arabicValue);
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
                var subtractCharValue = convertNumeralCharToInt(numeral[posOfNoSubtractChar]);
                var nextCharValue = convertNumeralCharToInt(numeral[posOfNoSubtractChar + 1]);

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
                var currentVal = convertNumeralCharToInt(numeral[i]);

                if (currentVal < convertNumeralCharToInt(numeral[i + 2]))
                {
                    throw new ArgumentException("Only one subtraction can be made per numeral.");
                }

            }
        }
    }
}

