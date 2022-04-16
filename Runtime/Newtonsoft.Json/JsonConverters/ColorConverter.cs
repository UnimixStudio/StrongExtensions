using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace StrongExtensions
{
	public class ColorConverter : JsonConverter<Color>
	{
		public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer) =>
			writer.WriteValue(ColorUtility.ToHtmlStringRGBA(value));

		public override Color ReadJson
			(JsonReader reader, Type objectType, Color existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			var value = jObject.Value<string>(reader);
			ColorUtility.TryParseHtmlString(value, out Color color);
			return color;
		}
	}
}