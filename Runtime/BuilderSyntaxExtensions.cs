using System;

namespace StrongExtensions
{
    public static class BuilderSyntaxExtensions
    {
        public static T With<T>(this T self, Action<T> action)
        {
            action(self);
            return self;
        }

        public static T With<T>(this T self, Action<T> action, bool when)
        {
            if (when)
                action(self);
            return self;
        }

        public static T With<T>(this T self, Action<T> action, Func<bool> when)
        {
            if (when())
                action(self);
            return self;
        }

        public static T With<T>(this T self, Action<T> action, Func<T, bool> when)
        {
            if (when(self))
                action(self);
            return self;
        }

        public static T When<T>(this T self, Func<T, bool> when, Action action)
        {
            if (when(self))
                action();
            return self;
        }

        public static T When<T>(this T self, Func<T, bool> when, Action<T> action)
        {
            if (when(self))
                action(self);

            return self;
        }

        public static T When<T>(this T self, bool when, Action<T> action)
        {
            if (when)
                action(self);

            return self;
        }
    }
}