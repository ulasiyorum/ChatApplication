using System.Text.Json.Serialization;

namespace ChatApplication_backend.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MessageType
    {
        Normal = 0,
        Green = 1,
        Alert = 2,
        Error = 3
    }
}
