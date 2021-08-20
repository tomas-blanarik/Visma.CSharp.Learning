namespace Session5.Helpers
{
    public static class StringHelper
    {
        public static bool IsEmailAddress(string str)
        {
            return !string.IsNullOrWhiteSpace(str) && str.Contains("@") && str.EndsWith(".com");
        }
    }
}
