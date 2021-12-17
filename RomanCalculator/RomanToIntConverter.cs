using System;

namespace Katas
{
    public class RomanToIntConverter
    {
        public static int ConvertRomanToInt(string numeral)
        {
            var arabicValue = 0;
            var numeralCharArr = numeral.ToCharArray();
            for (var index = 0; index < numeralCharArr.Length; index++)
            {
                var c = numeralCharArr[index];
                var currentValue = ConvertRomanCharToInt(c);
                var nextValue = index + 1 > numeralCharArr.Length - 1
                    ? 0
                    : ConvertRomanCharToInt(numeralCharArr[index + 1]);

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

        public static int ConvertRomanCharToInt(char numeral)
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
        
    }
}