namespace HealthCheckAlexa.WebApi
{
    using Alexa.Models;
    using Alexa.Models.SubModels;
    using System.Web.Http;
    using Umbraco.Web.WebApi;

    public class HealthCheckApiController : UmbracoAuthorizedApiController
    {
        [HttpPost]
        public AlexaResponse DoHealthChecks([FromBody]AlexaRequest request)
        {
            var response = new AlexaResponse
            {
                Version = "1.0",
                Response = new Response
                {
                    OutputSpeech = new OutputSpeech
                    {
                        Type = "PlainText",
                        Text = "Hello Alexa world!"
                    },
                    Card = new Card
                    {
                        Type = "Simple",
                        Title = "Title of the card",
                        Content = "Hello Alexa card world"
                    }
                },
                ShouldEndSession = true
            };

            return response;
        }
    }
}
