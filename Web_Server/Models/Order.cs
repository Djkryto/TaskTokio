using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Web_Server.Models
{
    /// <summary>
    /// Модель заказа.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Id в базе данных.
        /// </summary>
        [Key]
        [XmlElement(Type = typeof(int),ElementName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Наименование заказа.
        /// </summary>
        [XmlElement(Type = typeof(string), ElementName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// ФИО клиента.
        /// </summary>
        [XmlElement(Type = typeof(string), ElementName = "client")]
        public string Client { get; set; }

        /// <summary>
        /// Стоимость заказа.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "price")]
        public float Price { get; set; }
    }
}
