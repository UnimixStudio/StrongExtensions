using System.Drawing;
using AnimalSimulator.JsonConverters;
using Newtonsoft.Json;

namespace StrongExtensions
{
    public static class JsonExtensions
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings()
        {
            Converters =
            {
                new ColorConverter(),
                new UnityObjectConverter(),
                new IntReactivePropertyJsonConverter(),
                new FloatReactivePropertyJsonConverter(),
                new StringReactivePropertyJsonConverter(),
            }
        };

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