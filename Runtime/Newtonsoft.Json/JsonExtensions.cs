using AnimalSimulator.JsonConverters;
using Newtonsoft.Json;

namespace StrongExtensions
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerSettings Settings = new()
        {
            Converters =
            {
                new ColorConverter(),
                new UnityObjectConverter(),
            }
        };

        public static void PutConverter(JsonConverter converter)
        {
            if (converter == null)
                return;
            
            foreach (var jsonConverter in Settings.Converters)
            {
                if (jsonConverter.GetType() == converter.GetType())
                    return;
            }
            
            Settings.Converters.Add(converter);
        }

        public static string ToJson<T>(this T target, bool prettyPrint = false)
        {
            Formatting formatting = prettyPrint
                ? Formatting.Indented
                : Formatting.None;

            return JsonConvert.SerializeObject(target, formatting, Settings);
        }

        public static string ToPrettyJson<T>(this T target, string name = "") =>
            $"{name} : \n{JsonConvert.SerializeObject(target, Formatting.Indented, Settings)}";

        public static T FromJson<T>(this string json) =>
            JsonConvert.DeserializeObject<T>(json, Settings);
    }
}