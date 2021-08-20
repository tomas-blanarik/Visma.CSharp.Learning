namespace Session5.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmailAddress(this string str)
        {
            return !string.IsNullOrWhiteSpace(str) && str.Contains("@") && str.EndsWith(".com");
        }
    }
}
