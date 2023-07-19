using UnityEngine;

namespace StrongExtensions
{
	public static class ToColorExtensions
	{
		public static Color Parse(this string value) => 
			ColorUtility.TryParseHtmlString(value, out Color color) ? color : Color.white;
		public static string ToColor(this string value, Color color) => 
			value.ToHexColor(ColorUtility.ToHtmlStringRGB(color));

		public static string ToHexColor(this string value, string hexColor) => 
			$"<color=#{hexColor.Replace("#","")}>{value}</color>";

		public static string Black(this string value) =>
			value.ToColor(Color.black);

		public static string Blue(this string value) =>
			value.ToColor(Color.blue);

		public static string Clear(this string value) =>
			value.ToColor(Color.clear);

		public static string Cyan(this string value) =>
			value.ToColor(Color.cyan);

		public static string Gray(this string value) =>
			value.ToColor(Color.gray);

		public static string Green(this string value) =>
			value.ToColor(Color.green);
		public static string Orange(this string value) => 
			value.ToColor(Color.yellow + Color.red);

		public static string Grey(this string value) =>
			value.ToColor(Color.grey);

		public static string Magenta(this string value) =>
			value.ToColor(Color.magenta);

		public static string Red(this string value) =>
			value.ToColor(Color.red);

		public static string White(this string value) =>
			value.ToColor(Color.white);

		public static string Yellow(this string value) =>
			value.ToColor(Color.yellow);

		public static string ToColor(this bool value) =>
			value.ToString().ToColor(value ? Color.green : Color.red);
	}
}
