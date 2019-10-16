using System;
using Newtonsoft.Json;

namespace Unf.Core.Duo.Models.Converters
{
    public class FileTimestampConverter : JsonConverter
    {
        private readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DateTime timestamp = (DateTime)value;
            writer.WriteValue(timestamp.ToUniversalTime().ToString("u"));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader?.Value != null)
            {
                if (reader.Value is long || reader.Value is int)
                {
                    return _epoch.AddSeconds((long)reader.Value);
                }
                else if (reader.Value is string)
                {
                    if (long.TryParse((string)reader.Value, out long value))
                    {
                        return _epoch.AddSeconds(value);
                    }
                    if (DateTime.TryParse((string)reader.Value, out DateTime timestamp))
                    {
                        return timestamp;
                    }
                }
            }
            return DateTime.MinValue;
        }

        public override bool CanConvert(Type objectType) => objectType == typeof(long);
    }
}
