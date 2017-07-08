namespace Alexa.Models
{
    using SubModels;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class AlexaResponse
    {
        private readonly Dictionary<String, String> _sessionAttributes;

        public AlexaResponse()
        {
            _sessionAttributes = new Dictionary<String, String>();
        }

        [JsonProperty(PropertyName = "version")]
        public String Version { get; set; }

        [JsonProperty(PropertyName = "sessionAttributes")]
        public Dictionary<String, String> SessionAttributes
        {
            get
            {
                return _sessionAttributes;
            }
        }

        [JsonProperty(PropertyName = "response")]
        public Response Response { get; set; }

        [JsonProperty(PropertyName = "shouldEndSession")]
        public Boolean ShouldEndSession { get; set; }
    }
}
