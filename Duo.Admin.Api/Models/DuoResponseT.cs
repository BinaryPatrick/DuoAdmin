using System.Collections.Generic;
using Newtonsoft.Json;

namespace Unf.Core.Duo.Models
{
    public partial class DuoResponse<T>
    {
        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("stat")]
        public string Stat { get; set; }

        [JsonProperty("response")]
        public T Content { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }
    }
}
