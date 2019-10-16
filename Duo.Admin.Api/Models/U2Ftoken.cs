using System;
using Newtonsoft.Json;
using Unf.Core.Duo.Models.Converters;

namespace Unf.Core.Duo.Models
{
    public class U2Ftoken
    {
        [JsonProperty("date_added"), JsonConverter(typeof(FileTimestampConverter))]
        public DateTime DateAdded { get; set; }

        [JsonProperty("registration_id")]
        public string RegistrationId { get; set; }
    }
}
