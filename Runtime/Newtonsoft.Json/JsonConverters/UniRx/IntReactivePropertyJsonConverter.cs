using System;

using Newtonsoft.Json;

using UniRx;

namespace AnimalSimulator.JsonConverters
{
	public class IntReactivePropertyJsonConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
			writer.WriteValue(((IReadOnlyReactiveProperty<int>)value)?.Value ?? 0);

		public override object ReadJson
			(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) =>
			reader.TokenType == JsonToken.Null
				? new ReactiveProperty<int>()
				: new ReactiveProperty<int>(int.Parse(reader.Value.ToString()));

		public override bool CanConvert(Type objectType) =>
			objectType.IsAssignableFrom(typeof(IReadOnlyReactiveProperty<float>));
	}
}