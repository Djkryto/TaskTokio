using System.Xml;
using Web_Server.Models;

namespace Web_Server.Builder
{
    public class XMLStringBuilder
    {
        private const string ORDER = "Order";
        private const string ID = "Id";
        private const string NAME = "Name";
        private const string CLIENT = "Client";
        private const string PRICE = "Price";
        public XmlElement Order(XmlDocument xmlDocument,int id,string name,string client,float price)
        {
            XmlElement order = xmlDocument.CreateElement(string.Empty, ORDER, string.Empty);

            order.AppendChild(Element(xmlDocument, id,ID));
            order.AppendChild(Element(xmlDocument, name,NAME));
            order.AppendChild(Element(xmlDocument, client,CLIENT));
            order.AppendChild(Element(xmlDocument, price,PRICE));

            return order;
        }

        private XmlElement Element(XmlDocument xmlDocument,string name,string nameElementToXml)
        {
            XmlElement nameElement = xmlDocument.CreateElement(string.Empty, nameElementToXml, string.Empty);
            XmlText value = xmlDocument.CreateTextNode(name);
            nameElement.AppendChild(value);

            return nameElement;
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
