using System.Text;
using Web_Server.Appliaction;
using Web_Server.Models;

namespace Web_Server.Handler
{
    public class DataHandler
    {
        private readonly XMLHandler _xmlHandler;
        private readonly IOrderRepository _orderRepository;

        public DataHandler(IOrderRepository orderRepository)
        {
            _xmlHandler = new XMLHandler(new());
            _orderRepository = orderRepository;
        }

        public async Task<string> AddAsync(HttpContext context)
        {   
            var order = ReadContext(context);

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveAsync();

            return string.Empty;
        }

        public async Task<string> RemoveAsync(HttpContext context)
        {
            var order = ReadContext(context);

            try
            {
                _orderRepository.Remove(order);
                await _orderRepository.SaveAsync();
            }
            catch (Exception ex)
            {

            }
            return string.Empty;
        }

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
