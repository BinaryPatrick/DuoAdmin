using Newtonsoft.Json;

namespace Unf.Core.Duo.Models
{
    public class Metadata
    {
        [JsonProperty("next_offset")]
        public long NextOffset { get; set; }

        [JsonProperty("total_objects")]
        public long TotalObjects { get; set; }
    }
}