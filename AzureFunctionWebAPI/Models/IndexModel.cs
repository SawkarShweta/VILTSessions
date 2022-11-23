using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace AzureFunctionWebAPI.Models
{
    public class IndexModel
    {
        private AppSettings AppSettings { get; set; }

        public IndexModel(IOptions<AppSettings> settings)
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

            dynamic content = new { name="shweta" };

            CancellationToken cancellationToken= default;


            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, Url))
            using (var httpContent = CreateHttpContent(content))
            {
                request.Content = httpContent;

                using (var response = await client
                    .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    .ConfigureAwait(false))
                {

                    var resualtList = response.Content.ReadAsStringAsync();

                    //ViewData["SampleClass"] = resualtList.Result;

                    return "Ok";
                }


            }

        }
    }
}
