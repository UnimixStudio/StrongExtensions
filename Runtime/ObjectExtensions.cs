namespace StrongExtensions
{
    public static class ObjectExtensions
    {
        public static T IfNull<T>(this T value, T newValue)
            where T : class
            =>
                value ??= newValue;
    }
}