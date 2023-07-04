using System.Xml;

namespace Web_Server.Handler.ResultModel
{
    public class ResultXMlHandler
    {
        public string Body;
        public XmlDocument XMLDoc;

        public ResultXMlHandler(string body, XmlDocument xMLDoc)
        {
            Body = body;
            XMLDoc = xMLDoc;
        }
    }
}
