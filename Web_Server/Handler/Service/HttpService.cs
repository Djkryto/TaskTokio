using System.Text;
using Web_Server.Appliaction.Enum;
using Web_Server.Models;

namespace Web_Server.Handler.Service
{
    public class HttpService
    {
        private readonly HttpClient _httpClient;
        private readonly XMLHandler _xmlHandler;
        public HttpService(XMLHandler xmlHandler)
        {
            _httpClient = new();
            _xmlHandler = xmlHandler;
        }

        public string Add(HttpContext context)
        {
            var data = ReadContext(context,UrlLink.ADD);

            var responce = _httpClient.SendAsync(data).Result;
            responce.EnsureSuccessStatusCode();

            return responce.StatusCode.ToString();
        }

        public string Remove(HttpContext context)
        {
            var data = ReadContext(context, UrlLink.REMOVE);

            var responce = _httpClient.SendAsync(data).Result;
            responce.EnsureSuccessStatusCode();

            return responce.StatusCode.ToString();
        }

        public void GetAsync(HttpContext context)
        {
            HttpResponseMessage responce = _httpClient.GetAsync(UrlLink.GET).Result;
            responce.EnsureSuccessStatusCode();

            string body = responce.Content.ReadAsStringAsync().Result;
            var data = Encoding.UTF8.GetBytes(body);
            
            context.Response.Body.Write(data, 0, data.Length);
            responce.EnsureSuccessStatusCode();
        }

        private HttpRequestMessage ReadContext(HttpContext context,string uriLink)
        {
            var body = _xmlHandler.Read(context);
            var data = new HttpRequestMessage()
            {
                RequestUri = new(uriLink),
                Content = new StringContent(body,Encoding.UTF8,"text/xml"),
                Method = HttpMethod.Post,
            };

            return data;
        }
    }   
}
