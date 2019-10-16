using System;
using Newtonsoft.Json;
using Unf.Core.Duo.Models.Converters;

namespace Unf.Core.Duo.Models
{
    public partial class Webauthncredential
    {
        [JsonProperty("credential_name")]
        public string CredentialName { get; set; }

        [JsonProperty("date_added"), JsonConverter(typeof(FileTimestampConverter))]
        public DateTime DateAdded { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("webauthnkey")]
        public string Webauthnkey { get; set; }
    }
}
