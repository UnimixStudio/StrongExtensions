using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace StrongExtensions
{
    public static class DebugExtensions
    {
        private static readonly Dictionary<Type, IDebugColorDecorator> DebugColorDecorators =
            new Dictionary<Type, IDebugColorDecorator>()
            {
                [typeof(bool)] = new BoolDebugColorDecorator(),
                [typeof(int)] = new IntDebugColorDecorator(),
                [typeof(float)] = new FloatDebugColorDecorator(),
                [typeof(double)] = new DoubleDebugColorDecorator(),
                [typeof(long)] = new LongDebugColorDecorator(),
                [typeof(string)] = new StringDebugColorDecorator(),
                [typeof(Color)] = new ColorDebugColorDecorator(),
            };

        public static T Log<T>(this T value) =>
            Log(value, string.Empty);

        public static T Log<T>(this T value, string name)
        {
            Type type = typeof(T);

            if (name == string.Empty)
                name = type.Name;

            bool decoratorExist = DebugColorDecorators.ContainsKey(type);

            string logName = decoratorExist
                ? DebugColorDecorators[type].DecorateName(name)
                : $"{name}";
            
            string logValue = decoratorExist
                ? DebugColorDecorators[type].DecorateValue(value)
                : $"{value}";

            Debug.Log($"{logName} : {logValue}", value as Object);

            return value;
        }

        public static T LogAsJson<T>(this T value, string name = "")
        {
            Type type = typeof(T);
            if (name.IsNullOrEmpty())
                name = type.Name;

            string prettyJson = value.ToPrettyJson(name);
            Debug.Log(prettyJson);
            return value;
        }

        public static IEnumerable<T> Log<T>(this IEnumerable<T> source)
        {
            IEnumerable<T> log = source as T[] ?? source.ToArray();

            Debug.Log(log.Count());

            IEnumerable<string> enumerable = log.Select(
                arg => arg != null
                    ? arg.ToString()
                    : "null");

            Debug.Log(string.Join("\n", enumerable));

            return log;
        }

        public static IEnumerable<T> LogAsJson<T>(this IEnumerable<T> source, string name = null)
        {
            IEnumerable<T> log = source as T[] ?? source.ToArray();

            Debug.Log(log.Count());

            if (name.IsNullOrEmpty())
                name = typeof(T).Name;

            Debug.Log(log.ToPrettyJson(name));

            return log;
        }

        public static List<T> LogEvery<T>(this List<T> source) =>
            LogEvery(source as IEnumerable<T>)
                .ToList();

        public static T[] LogEvery<T>(this T[] source) =>
            LogEvery(source as IEnumerable<T>)
                .ToArray();

        public static IEnumerable<T> LogEvery<T>(this IEnumerable<T> source)
        {
            IEnumerable<T> logEvery = source as T[] ?? source.ToArray();
            IEnumerable<T> log = source as T[] ?? logEvery.ToArray();

            Type type = source.GetType();
            bool isGenericType = type.IsGenericType;

            string typeName = type.Name;
            typeName = typeName.ToHexColor(HexColors.SandyBrown);

            if (isGenericType)
            {
                Type argument = type.GenericTypeArguments.FirstOrDefault();

                string argumentName = argument == null ? string.Empty : argument.Name;

                typeName = typeName.Replace("`1", $"<{argumentName.ToHexColor(HexColors.DarkSlateGray)}>");
            }

            string name = typeName;

            string count = log.Count().ToString().ToHexColor(HexColors.LightSkyBlue);

            var message = $"{name} Count : {count}";

            Debug.Log(message);

            foreach (T s in log)
            {
                message = s.ToString().ToHexColor(HexColors.CornflowerBlue);

                Debug.Log(message, s as Object);
            }

            return logEvery;
        }

        public static void LogMethod<T>(this T instance, string methodName) =>
            Debug.Log(
                $"{typeof(T).Name.ToHexColor(HexColors.Shamrock)}({instance.GetHashCode()}).{methodName.ToHexColor(HexColors.SandyBrown)}",
                instance as Object);

        public static void LogConstructor<T>(this T instance) =>
            Debug.Log($"{typeof(T).Name.ToHexColor(HexColors.Shamrock)}({instance.GetHashCode()})", instance as Object);
    }
}