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
		private static readonly Dictionary<Type, IDebugColorDecorator> DebugColorDecorators = new()
		{
			[typeof(bool)] = new BoolDebugColorDecorator(),
			[typeof(int)] = new IntDebugColorDecorator(),
			[typeof(float)] = new FloatDebugColorDecorator(),
			[typeof(double)] = new DoubleDebugColorDecorator(),
			[typeof(long)] = new LongDebugColorDecorator(),
			[typeof(string)] = new StringDebugColorDecorator(),
			[typeof(Color)] = new ColorDebugColorDecorator(),
			[typeof(Vector3)] = new Vector3DebugColorDecorator(),
			[typeof(Vector2)] = new Vector2DebugColorDecorator(),
		};

		[HideInCallstack]
		public static T Log<T>(this T value) => Log(value, string.Empty);

		[HideInCallstack]
		public static T Log<T>(this T value, string name)
		{
			string message = value.LogMessage(name);

			Debug.Log(message, value as Object);

			return value;
		}

		[HideInCallstack]
		public static string LogMessage<T>(this T value, string name = default)
		{
			Type type = typeof(T);

			if (name == default)
				name = type.Name;

			bool decoratorExist = DebugColorDecorators.ContainsKey(type);

			string logName = decoratorExist
				? DebugColorDecorators[type].DecorateName(name)
				: $"{name}";

			string logValue = decoratorExist ? DebugColorDecorators[type].DecorateValue(value) :
				value == null ? "null".ToHexColor("#499cd5") : value.ToString();

			return$"{logName} : {logValue} {(value as Object)?.GetInstanceID()}";
		}

		[HideInCallstack]
		public static T LogAsJson<T>(this T value, string name = "")
		{
			Type type = typeof(T);

			if (name.IsNullOrEmpty())
				name = type.Name;

			string prettyJson = value.ToPrettyJson(name);
			Debug.Log(prettyJson);

			return value;
		}

		[HideInCallstack]
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

		[HideInCallstack]
		public static IEnumerable<T> LogAsJson<T>(this IEnumerable<T> source, string name = null)
		{
			IEnumerable<T> log = source as T[] ?? source.ToArray();

			Debug.Log(log.Count());

			if (name.IsNullOrEmpty())
				name = typeof(T).Name;

			Debug.Log(log.ToPrettyJson(name));

			return log;
		}

		[HideInCallstack]
		public static List<T> LogEvery<T>(this List<T> source) =>
			LogEvery(source as IEnumerable<T>).ToList();

		[HideInCallstack]
		public static T[] LogEvery<T>(this T[] source) =>
			LogEvery(source as IEnumerable<T>).ToArray();

		[HideInCallstack]
		public static IEnumerable<T> LogEvery<T>(this IEnumerable<T> source, string name = null)
		{
			if (source == null)
			{
				Debug.Log($"{name} : Null");
				return source;
			}

			name ??= GetTypeName(source);

			T[] log = source as T[] ?? source.ToArray();

			string count = log.Length.ToString().ToHexColor(HexColors.LightSkyBlue);

			var stringDebugColorDecorator = new StringDebugColorDecorator();
			name = stringDebugColorDecorator.DecorateValue(name);

			Debug.Log($"{name} " + count.LogMessage("Count"));

			for (var i = 0; i < log.Length; i++)
				log[i].Log($"[{i}]");

			return source;
		}

		[HideInCallstack]
		private static string GetTypeName<T>(IEnumerable<T> source)
		{
			Type type = source.GetType();

			string typeName = type.Name;

			bool isGenericType = type.IsGenericType;

			if (isGenericType == false)
				return typeName.ToHexColor(HexColors.SandyBrown);

			string argumentName = GetArgumentName<T>(type);

			return typeName.Replace("`1", $"<{argumentName.ToHexColor(HexColors.DarkSlateGray)}>");
		}

		[HideInCallstack]
		private static string GetArgumentName<T>(Type type)
		{
			Type[] genericTypeArguments = type.GenericTypeArguments;

			Type argument = genericTypeArguments.FirstOrDefault();

			bool argumentExists = argument != null;

			return argumentExists
				? argument.Name
				: string.Empty;
		}

		[HideInCallstack]
		public static T LogMethod<T>(this T instance, string methodName) =>
			instance.With(
				x => Debug.Log(
					$"{typeof(T).Name.ToHexColor(HexColors.Shamrock)}({x.GetHashCode()})." +
					$"{methodName.ToHexColor(HexColors.SandyBrown)}",
					x as Object));

		[HideInCallstack]
		public static void LogConstructor<T>(this T instance) =>
			Debug.Log($"{typeof(T).Name.ToHexColor(HexColors.Shamrock)}({instance.GetHashCode()})", instance as Object);
	}
}
