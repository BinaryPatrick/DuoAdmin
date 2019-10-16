using Newtonsoft.Json;

namespace Unf.Core.Duo.Models
{
    public partial class Group
    {
        [JsonProperty("desc")]
        public string Desc { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
