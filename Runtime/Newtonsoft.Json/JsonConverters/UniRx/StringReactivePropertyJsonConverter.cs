using System;

using Newtonsoft.Json;

using UniRx;

namespace AnimalSimulator.JsonConverters
{
	public class StringReactivePropertyJsonConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
			writer.WriteValue(value == null ? "" : ((StringReactiveProperty)value).Value);

		public override object ReadJson
		(
			JsonReader reader,
			Type objectType,
			object existingValue,
			JsonSerializer serializer
		) =>
			reader.TokenType == JsonToken.Null
				? new StringReactiveProperty()
				: new StringReactiveProperty(reader.Value.ToString());

		public override bool CanConvert(Type objectType) =>
			objectType == typeof(StringReactiveProperty);
	}
}