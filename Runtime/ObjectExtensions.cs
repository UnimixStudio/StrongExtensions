using System;

namespace StrongExtensions
{
    public static class ObjectExtensions
    {
        [Obsolete("Use SetIfNull")]
        public static T IfNull<T>(this T source, T newValue)
            where T : class
            => source.SetIfNull(newValue);
        
        
        public static T SetIfNull<T>(this T SetIfNull, T newValue)
            where T : class
            =>
                SetIfNull ??= newValue;
    }
}