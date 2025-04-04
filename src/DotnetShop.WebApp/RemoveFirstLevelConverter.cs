using System.Text.Json.Serialization;
using System.Text.Json;

namespace DotnetShop.WebApp
{
    public class RemoveFirstLevelConverter<T> : JsonConverter<T>
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                foreach (JsonProperty property in doc.RootElement.EnumerateObject())
                {
                    return JsonSerializer.Deserialize<T>(property.Value.GetRawText(), options);
                }

                throw new JsonException("No properties found in JSON.");
            }
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("root");
            JsonSerializer.Serialize(writer, value, options);
            writer.WriteEndObject();
        }
    }
}
