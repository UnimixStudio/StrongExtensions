using System;

using Newtonsoft.Json;

using UniRx;

namespace AnimalSimulator.JsonConverters
{
	public class StringReactivePropertyJsonConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
			writer.WriteValue(value == null ? "" : ((IReadOnlyReactiveProperty<string>)value).Value);

		public override object ReadJson
		(
			JsonReader reader,
			Type objectType,
			object existingValue,
			JsonSerializer serializer
		) =>
			reader.TokenType == JsonToken.Null
				? new ReactiveProperty<string>()
				: new ReactiveProperty<string>(reader.Value.ToString());

		public override bool CanConvert(Type objectType) =>
			objectType.IsAssignableFrom(typeof(IReadOnlyReactiveProperty<string>));
	}
}