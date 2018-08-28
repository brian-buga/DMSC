namespace DMSC.Assessment.Web.Extensions
{
    public static class StringExtension
    {
        public static string ShortString(this string value, int length)
        {
            if(value.Length < length)
            {
                return value;
            }

            return value.Substring(0, length);
        }
    }
}
