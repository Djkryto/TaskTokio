using Web_Server.Appliaction.Handler;
using Web_Server.Appliaction.Enum;
using System.Text;

namespace Web_Server.Handler.Service
{
    /// <summary>
    /// Класс отвечающий за запросы.
    /// </summary>
    public class HttpService
    {
        private readonly HttpClient _httpClient;
        private readonly XMLHandler _xmlHandler;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="xmlHandler">Обрабочтки xml файла.</param>
        public HttpService(XMLHandler xmlHandler)
        {
            _httpClient = new();
            _xmlHandler = xmlHandler;
        }

        /// <summary>
        /// Отправка данных на сервер через HttpClient.
        /// </summary>
        /// <param name="context">контекст контроллера</param>
        /// <returns></returns>
        public string Add(HttpContext context)
        {
            var data = ReadContext(context,UrlLink.ADD);

            var responce = _httpClient.SendAsync(data).Result;
            responce.EnsureSuccessStatusCode();

            return responce.StatusCode.ToString();
        }

        /// <summary>
        /// Отправка данных на сервер через HttpClient.
        /// </summary>
        /// <param name="context">контекст контроллера</param>
        /// <returns></returns>
        public string Remove(HttpContext context)
        {
            var data = ReadContext(context, UrlLink.REMOVE);

            var responce = _httpClient.SendAsync(data).Result;
            responce.EnsureSuccessStatusCode();

            return responce.StatusCode.ToString();
        }

        /// <summary>
        /// Получение данных с сервера через HttpClient.
        /// </summary>
        /// <param name="context">контекст контроллера</param>
        /// <returns></returns>
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
