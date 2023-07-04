using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Web_Server.Models
{
    public class Order
    {
        [Key]
        [XmlElement(Type = typeof(int),ElementName = "id")]
        public int Id { get; set; }

        [XmlElement(Type = typeof(string), ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(Type = typeof(string), ElementName = "client")]
        public string Client { get; set; }
        [XmlElement(Type = typeof(float), ElementName = "price")]
        public float Price { get; set; }
    }
}
