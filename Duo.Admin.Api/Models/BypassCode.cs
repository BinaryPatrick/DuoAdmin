using System;
using Newtonsoft.Json;
using Unf.Core.Duo.Models.Converters;

namespace Unf.Core.Duo.Models
{
    public class BypassCode
    {
        [JsonProperty("bypass_code_id")]
        public string BypassCodeId { get; set; }

        [JsonProperty("created"), JsonConverter(typeof(FileTimestampConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("expiration"), JsonConverter(typeof(FileTimestampConverter))]
        public DateTime Expiration { get; set; }

        [JsonProperty("reuse_count")]
        public long ReuseCount { get; set; }
    }
}
