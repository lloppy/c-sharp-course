using System.Linq;

namespace Pluralize
{
    public static class PluralizeTask
    {
        public static string PluralizeRubles(int count)
        {
            var lastDigitOfCorrectNumber = new[] {2, 3, 4};
            var unitDigit = count % 10;
            var tensDigit = count % 100;

            if (!(tensDigit >= 5 && tensDigit <= 20))
            {
                if (unitDigit == 1) return "рубль";
                if (lastDigitOfCorrectNumber.Contains(unitDigit)) return "рубля";
            }
            return "рублей";
        }
    }
}