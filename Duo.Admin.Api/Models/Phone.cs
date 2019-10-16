using System.Collections.Generic;
using Newtonsoft.Json;

namespace Unf.Core.Duo.Models
{
    public partial class Phone
    {
        [JsonProperty("phone_id")]
        public string PhoneId { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("postdelay")]
        public dynamic Postdelay { get; set; }

        [JsonProperty("predelay")]
        public dynamic Predelay { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("capabilities")]
        public List<string> Capabilities { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("activated")]
        public bool Activated { get; set; }

        [JsonProperty("sms_passcodes_sent")]
        public bool SmsPasscodesSent { get; set; }
    }
}
