namespace Application.Helpers
{
    public static class CheckValidationHelper
    {
        public static bool IsNullOrDefault<T>(T value)
        {
            var result = value == null || EqualityComparer<T>.Default.Equals(value, default(T));
            return result;
        }

        public static bool IsIntOrLong(object value)
        {
            return value is int || value is long;
        }

        public static bool IsValidLongArray(List<long> array)
        {
            return array != null && array.Count >= 1 && array.All(element => true);
        }
    }
}
