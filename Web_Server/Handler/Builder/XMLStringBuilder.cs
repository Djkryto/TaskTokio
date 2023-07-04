using Web_Server.Models;
using System.Xml;

namespace Web_Server.Appliaction.Builder
{
    /// <summary>
    /// Класс создающий элемент xml файла модели Order.
    /// </summary>
    public class XMLStringBuilder
    {
        private const string ORDER = "Order";
        private const string ID = "Id";
        private const string NAME = "Name";
        private const string CLIENT = "Client";
        private const string PRICE = "Price";

        /// <summary>
        /// Создать элемент order xml формата в виде Elementa.
        /// </summary>
        /// <param name="xmlDocument">XML Документ</param>
        /// <param name="orderModel">Заказ</param>
        /// <returns>XmlElement</returns>
        public XmlElement CreateOrder(XmlDocument xmlDocument, Order orderModel)
        {
            XmlElement order = xmlDocument.CreateElement(string.Empty, ORDER, string.Empty);

            order.AppendChild(Element(xmlDocument, orderModel.Id, ID));
            order.AppendChild(Element(xmlDocument, orderModel.Name, NAME));
            order.AppendChild(Element(xmlDocument, orderModel.Client, CLIENT));
            order.AppendChild(Element(xmlDocument, orderModel.Price, PRICE));

            return order;
        }

        private XmlElement Element<T>(XmlDocument xmlDocument, T price, string nameElementToXml)
        {
            XmlElement nameElement = xmlDocument.CreateElement(string.Empty, nameElementToXml, string.Empty);
            XmlText value = xmlDocument.CreateTextNode(price.ToString());
            nameElement.AppendChild(value);

            return nameElement;
        }
    }
}
