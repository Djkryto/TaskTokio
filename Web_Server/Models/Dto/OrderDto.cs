using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Web_Server.Models;

[XmlRoot("order")]
public class OrderDto
{
    [Key]
    [XmlElement(ElementName = "id")]
    public int Id { get; set; }
    [XmlElement(ElementName = "name")]
    public string Name { get; set; }
    [XmlElement(ElementName = "client")]
    public string Client { get; set; }
    [XmlElement(ElementName = "price")]
    public float Price { get;set; }
}