namespace Alexa.Models.SubModels
{
    using Newtonsoft.Json;

    public class Response
    {
        [JsonProperty(PropertyName = "outputSpeech")]
        public OutputSpeech OutputSpeech { get; set; }

        [JsonProperty(PropertyName = "card")]
        public Card Card { get; set; }
    }
}
