using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Object = UnityEngine.Object;

namespace AnimalSimulator.JsonConverters
{
	public class UnityObjectConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value == null)
				writer.WriteNull();
			else
				writer.WriteValue(((Object)value).name);
		}

		public override object ReadJson
			(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null)
				return "Null";
			JObject jObject = JObject.Load(reader);
			return jObject.Value<string>(reader);
		}

		public override bool CanConvert(Type objectType) =>
			objectType.IsSubclassOf(typeof(Object));
	}
}