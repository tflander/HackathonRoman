using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApp1;


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
        public static string Add(string numeral1, string numeral2)
        {
            RomanStringValidator.ValidateRomanString(numeral1);
            RomanStringValidator.ValidateRomanString(numeral2);

            var arabicResult = RomanToIntConverter.ConvertRomanToInt(numeral1) + RomanToIntConverter.ConvertRomanToInt(numeral2);
            return IntToRomanConverter.ConvertIntToRoman(arabicResult);
        }
    }
}

