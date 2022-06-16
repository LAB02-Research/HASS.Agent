using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace HASS.Agent.API
{
    /// <summary>
    /// Deserialization options for the local API
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public abstract class ApiDeserialization
    {
        public static JsonSerializerOptions SerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public static async Task<T> DeserializeAsync<T>(Stream stream)
        {
            return await DeserializeAsync<T>(stream, CancellationToken.None);
        }

        public static async Task<T> DeserializeAsync<T>(Stream stream, CancellationToken token)
        {
            return await JsonSerializer.DeserializeAsync<T>(stream, SerializerOptions, token);
        }
    }
}
