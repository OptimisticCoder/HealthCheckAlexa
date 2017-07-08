namespace Alexa.Models.SubModels
{
    using System;
    using Newtonsoft.Json;

    public class Card
    {
        [JsonProperty(PropertyName = "type")]
        public String Type { get; set; }

        [JsonProperty(PropertyName = "title")]
        public String Title { get; set; }

        [JsonProperty(PropertyName = "content")]
        public String Content { get; set; }
    }
}
