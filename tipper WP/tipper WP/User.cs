using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace tipper_WP.Data
{
    public class User
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }
    }
}
