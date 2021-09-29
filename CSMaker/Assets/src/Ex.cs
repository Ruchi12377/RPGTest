namespace src
{
    public static class Ex
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }
    }
}