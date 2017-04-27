namespace ArabWaha.Helpers
{
    public static class ParserHelper
    {
        public static int ParseStringToInt(string s)
        {
            int i;
            int.TryParse(s, out i);
            return i;
        }

        public static string ParseString(string s) => string.IsNullOrEmpty(s) ? "" : s;

        public static string ParseObjectToString(object o) => o == null ? "" : o.ToString();
    }
}