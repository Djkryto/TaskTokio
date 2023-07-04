using Web_Server.Appliaction.Builder;
using System.Xml.Serialization;
using Web_Server.Models;
using System.Text;
using System.Xml;

namespace Web_Server.Appliaction.Handler
{
    /// <summary>
    /// Класс обрабатывающий xml файл.
    /// </summary>
    public class XMLHandler
    {
        private readonly XMLStringBuilder _xmlStringBuilder;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="xmlStringBuilder"></param>
        public XMLHandler(XMLStringBuilder xmlStringBuilder) => _xmlStringBuilder = xmlStringBuilder;

        /// <summary>
        /// Конвертация xml строки в модель order.
        /// </summary>
        /// <param name="body">xml строка</param>
        /// <returns></returns>
        public Order Deserialize(string body)
        {
            var order = new Order();
            var serialize = new XmlSerializer(typeof(Order));

            using (XmlReader reader = XmlReader.Create(new StringReader(body)))
            {
                order = (Order)serialize.Deserialize(reader);
            }
            
            return order;
        }

        /// <summary>
        /// Чтение xml файла из контектса.
        /// </summary>
        /// <param name="context">Контекст контроллера</param>
        /// <returns></returns>
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

        /// <summary>
        /// Создание xml файла из массива моделей.
        /// </summary>
        /// <param name="orders">Масси заказов</param>
        /// <returns></returns>
        public string CreateXmlDoc(Order[] orders)
        {
            var xmlDoc = new XmlDocument();

            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = xmlDoc.DocumentElement;

            xmlDoc.InsertBefore(xmlDeclaration, root);

            XmlElement main = xmlDoc.CreateElement(string.Empty, "body", string.Empty);
            xmlDoc.AppendChild(main);

            for (int i = 0; i < orders.Length; i++)
                main.AppendChild(_xmlStringBuilder.CreateOrder(xmlDoc, orders[i]));

            return xmlDoc.DocumentElement.OuterXml;
        }
    }
}
