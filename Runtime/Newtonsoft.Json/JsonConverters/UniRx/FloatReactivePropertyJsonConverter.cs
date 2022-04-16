using System;

using Newtonsoft.Json;

using UniRx;

namespace AnimalSimulator.JsonConverters
{
	public class FloatReactivePropertyJsonConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
			writer.WriteValue(((FloatReactiveProperty)value)?.Value ?? 0f);

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) =>
			reader.TokenType == JsonToken.Null
				? new FloatReactiveProperty()
				: new FloatReactiveProperty(float.Parse(reader.Value.ToString()));

		public override bool CanConvert(Type objectType) =>
			objectType == typeof(FloatReactiveProperty);
	}
}