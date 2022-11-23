using AzureFunctionWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace AzureFunctionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AzureFunctionController : ControllerBase
    {
        private AppSettings AppSettings { get; set; }

        public AzureFunctionController(IOptions<AppSettings> settings)
        {
            AppSettings = settings.Value;
        }

        public static void SerializeJsonIntoStream(object value, Stream stream)
        {
            using (var sw = new StreamWriter(stream, new UTF8Encoding(false), 1024, true))
            using (var jtw = new JsonTextWriter(sw) { Formatting = Formatting.None })
            {
                var js = new JsonSerializer();
                js.Serialize(jtw, value);
                jtw.Flush();
            }
        }

        private static HttpContent CreateHttpContent(object content)
        {
            HttpContent httpContent = null;

            if (content != null)
            {
                var ms = new MemoryStream();
                SerializeJsonIntoStream(content, ms);
                ms.Seek(0, SeekOrigin.Begin);
                httpContent = new StreamContent(ms);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            return httpContent;
        }

        [HttpGet]
        [Route("PassNameByName")]
        public async Task<string> PassNameByName(string name)
        {
            var Url = AppSettings.AzureFunctionURL;

            dynamic content = new { name = name };

            CancellationToken cancellationToken = default;


            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, Url))
            using (var httpContent = CreateHttpContent(content))
            {
                request.Content = httpContent;

                using (var response = await client
                    .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    .ConfigureAwait(false))
                {

                    var result = response.Content.ReadAsStringAsync().Result;

                    //ViewData["SampleClass"] = resualtList.Result;

                    return result;
                }


            }

        }
    }
}
