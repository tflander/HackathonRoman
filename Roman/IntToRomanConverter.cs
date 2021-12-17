using System.Collections.Generic;
using System.Text;

namespace Katas
{
    public class IntToRomanConverter
    {
        public static string ConvertIntToRoman(int arabicValue)
        {
            int number = arabicValue;
            var retValue = new StringBuilder();
            var arabicValues = new List<int>() { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            var romanDigits = new List<string>()
                { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };

            while (number > 0)
            {
                for (var i = arabicValues.Count - 1; i >= 0; i--)
                    if (number / arabicValues[i] >= 1)
                    {
                        number -= arabicValues[i];
                        retValue.Append(romanDigits[i]);
                        break;
                    }
            }

            return retValue.ToString();
        }
    }
}