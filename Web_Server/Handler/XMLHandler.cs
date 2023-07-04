using System.Xml.Serialization;
using System.Xml;
using Web_Server.Models;
using System.Text;
using Web_Server.Builder;

namespace Web_Server.Handler
{
    public class XMLHandler
    {
        private readonly XMLStringBuilder _xmlStringBuilder;

        public XMLHandler(XMLStringBuilder xmlStringBuilder)
        {
            _xmlStringBuilder = xmlStringBuilder;
        }

        public Order Deserialize(string body)
        {
            var order = new Order();
            Console.WriteLine("Reading with Stream");
            try
            {
                var serialize = new XmlSerializer(typeof(Order));

                using (XmlReader reader = XmlReader.Create(new StringReader(body)))
                {
                    order = (Order)serialize.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {

            }
            // Declare an object variable of the type to be deserialized.

            return order;
        }

        public void Serialize()
        {
            var xmlDoc = new XmlSerializer(typeof(OrderDto));
            var textWrite = new StringWriter();

            var order = new OrderDto();

            order.Name = "Суши";
            order.Client = "Лерова Александра Денилова";
            order.Price = 321.33f;


            xmlDoc.Serialize(textWrite, order);
            textWrite.Close();

        }

        public string Read(HttpContext context)
        {
            string body = "";

            using (var stream = new StreamReader(context.Request.Body))
            {
                body = stream.ReadToEnd();

                string _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
                if (body.StartsWith(_byteOrderMarkUtf8))
                {
                    var lastIndexOfUtf8 = _byteOrderMarkUtf8.Length - 1;
                    body = body.Remove(0, lastIndexOfUtf8);
                }
            }

            return body;
        }

        public string CreateXmlDoc(Order[] orders)
        {
            var xmlDoc = new XmlDocument();

            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = xmlDoc.DocumentElement;
            xmlDoc.InsertBefore(xmlDeclaration, root);

            XmlElement main = xmlDoc.CreateElement(string.Empty, "body", string.Empty);
            xmlDoc.AppendChild(main);

            for(int i = 0;i < orders.Length; i++)
                main.AppendChild(_xmlStringBuilder.Order(xmlDoc, orders[i].Id,orders[i].Name, orders[i].Client, orders[i].Price));

            xmlDoc.Save("E:\\doc.xml");

            return xmlDoc.DocumentElement.OuterXml;
        }


        // Code Read() 
        //var result =_xmlHandler.Read(HttpContext);

        //var xmlDoc = result.XMLDoc;
        //var body = result.Body;

        //var order = _xmlHandler.Deserialize(body);

        //_orderRepository.Add(order);
        //await _orderRepository.SaveAsync();
    }
}
