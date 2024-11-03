namespace Soma.Api.Extensions
{
    public static class StringExtensions
    {        
        public static bool IsValidDouble(this string value)
        {
            return double.TryParse(value, out _);
        }
       
        public static double ToDouble(this string value)
        {
            if (double.TryParse(value, out double result))
            {
                return result;
            }
            return 0;
        }
    }
}
