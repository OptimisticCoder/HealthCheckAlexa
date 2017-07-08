namespace Alexa.Models.SubModels
{
    using System;
    using Newtonsoft.Json;

    public class OutputSpeech
    {
        [JsonProperty(PropertyName = "type")]
        public String Type { get; set; }

        [JsonProperty(PropertyName = "text")]
        public String Text { get; set; }
    }
}
