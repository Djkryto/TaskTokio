using Web_Server.Appliaction.Handler;
using Web_Server.Appliaction;
using Web_Server.Models;
using System.Text;

namespace Web_Server.Handler
{
    /// <summary>
    /// Обработчик полученных запросов.
    /// </summary>
    public class DataHandler
    {
        private readonly XMLHandler _xmlHandler;
        private readonly IOrderRepository _orderRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="orderRepository"></param>
        public DataHandler(IOrderRepository orderRepository)
        {
            _xmlHandler = new XMLHandler(new());
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Добавление данных в базу данных.
        /// </summary>
        /// <param name="context">Контекст контроллера</param>
        /// <returns></returns>
        public async Task<string> AddAsync(HttpContext context)
        {   
            var order = ReadContext(context);

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveAsync();

            return string.Empty;
        }

        /// <summary>
        /// Удаление данных из базу данных.
        /// </summary>
        /// <param name="context">Контекст контроллера</param>
        /// <returns></returns>
        public async Task<string> RemoveAsync(HttpContext context)
        {
            var order = ReadContext(context);

            _orderRepository.Remove(order);
            await _orderRepository.SaveAsync();
            
            return string.Empty;
        }

        /// <summary>
        /// Получение данных из базу данных. Получение осуществляется записью в контекст.
        /// </summary>
        /// <param name="context">Контекст контроллера</param>
        /// <returns></returns>
        public void Get(HttpContext context)
        {
            var orders = _orderRepository.Get().ToArray();
            var xmlString = _xmlHandler.CreateXmlDoc(orders);
            var bytes = Encoding.UTF8.GetBytes(xmlString);

            context.Response.ContentType = "text/xml";
            context.Response.Body.Write(bytes, 0, bytes.Length);
        }

        private Order ReadContext(HttpContext context)
        {
            var body = _xmlHandler.Read(context);
            var order = _xmlHandler.Deserialize(body);

            return order;
        }
    }
}
