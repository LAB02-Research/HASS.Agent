using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace HASSAgent.Notifications
{
    /// <summary>
    /// Deserialization options for the Notification API
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public abstract class NotifierDeserialization
    {
        public static JsonSerializerOptions SerializerOptions = new JsonSerializerOptions()
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
