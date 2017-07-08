namespace HealthCheckAlexa.WebApi
{
    using Alexa.Models;
    using Alexa.Models.SubModels;
    using System.Net.Http;
    using System.Web.Http;
    using Umbraco.Web.WebApi;
    using Newtonsoft.Json;
    using System.Text;
    using Umbraco.Web.HealthCheck;
    using Umbraco.Web.HealthCheck.Checks.Services;
    using System.Linq;

    public class HealthCheckApiController : UmbracoApiController
    {
        
        [HttpPost]
        public HttpResponseMessage DoHealthChecks([FromBody]AlexaRequest request)
        {
            var context = new HealthCheckContext(UmbracoContext.HttpContext, UmbracoContext);

            var smtp = new SmtpCheck(context);
            var statuses = smtp.GetStatus();

            var sb = new StringBuilder();
            var index = 0;
            foreach(var s in statuses)
            {
                if (sb.Length == 0)
                    sb.Append(s.Message);
                else if (index == statuses.Count() - 1 && statuses.Count() > 1)
                    sb.Append(", and " + s.Message);
                else
                    sb.Append(", " + s.Message);

                index++;
            }

            if (sb.Length == 0)
                sb.Append("The health check returned no results.");

            var response = new AlexaResponse
            {
                Version = "1.0",
                Response = new Response
                {
                    OutputSpeech = new OutputSpeech
                    {
                        Type = "PlainText",
                        Text = sb.ToString()
                    },
                    Card = new Card
                    {
                        Type = "Simple",
                        Title = "Health Check Results",
                        Content = sb.ToString()
                    }
                },
                ShouldEndSession = true
            };

            return new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(response), 
                                            Encoding.UTF8, 
                                            "application/json")
            };
        }
    }
}
