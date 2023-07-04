using Web_Server.Models;

namespace Web_Server.Appliaction
{
    /// <summary>
    /// Интерфейс для взаимодействия с репозиторием.
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Добавление заказа в базу данных.
        /// </summary>
        /// <param name="order">Модель заказа</param>
        /// <returns></returns>
        public Task AddAsync(Order order);

        /// <summary>
        /// Удаления заказа из базы данных.
        /// </summary>
        /// <param name="order">Модель заказа</param>
        /// <returns></returns>
        public void Remove(Order order);

        /// <summary>
        /// Сохранение изменений в базе данных.
        /// </summary>
        /// <param name="order">Модель заказа</param>
        /// <returns></returns>
        public Task SaveAsync();

        /// <summary>
        /// Получение заказов из базы данных.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Order> Get();
    }
}
