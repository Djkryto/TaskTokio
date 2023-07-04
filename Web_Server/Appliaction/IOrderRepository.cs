using Web_Server.Models;

namespace Web_Server.Appliaction
{
    public interface IOrderRepository
    {
        public Task AddAsync(Order order);
        public void Remove(Order order);
        public Task SaveAsync();
        public IEnumerable<Order> Get();
    }
}
