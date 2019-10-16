using System.Collections.Generic;
using Newtonsoft.Json;

namespace Unf.Core.Duo.Models
{
    public partial class Token
    {
        [JsonProperty("serial")]
        public string Serial { get; set; }

        [JsonProperty("token_id")]
        public string TokenId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("totp_step")]
        public object TotpStep { get; set; }

        [JsonProperty("users")]
        public List<User> Users { get; set; }
    }
}
