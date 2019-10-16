using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Unf.Core.Duo.Models.Converters;

namespace Unf.Core.Duo.Models
{
    public partial class User
    {
        [JsonProperty("alias1")]
        public string Alias1 { get; set; }

        [JsonProperty("alias2")]
        public string Alias2 { get; set; }

        [JsonProperty("alias3")]
        public string Alias3 { get; set; }

        [JsonProperty("alias4")]
        public string Alias4 { get; set; }

        [JsonProperty("created"), JsonConverter(typeof(FileTimestampConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }

        [JsonProperty("is_enrolled")]
        public bool IsEnrolled { get; set; }

        [JsonProperty("last_directory_sync"), JsonConverter(typeof(FileTimestampConverter))]
        public DateTime LastDirectorySync { get; set; }

        [JsonProperty("last_login"), JsonConverter(typeof(FileTimestampConverter))]
        public DateTime LastLogin { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("phones")]
        public List<Phone> Phones { get; set; }

        [JsonProperty("realname")]
        public string Realname { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("tokens")]
        public List<Token> Tokens { get; set; }

        [JsonProperty("u2ftokens")]
        public List<U2Ftoken> U2Ftokens { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("webauthncredentials")]
        public List<Webauthncredential> Webauthncredentials { get; set; }
    }
}
