using Web_Server.Models;
using Web_Server.Appliaction;
using Web_Server.Database.Context.Sql;

namespace Web_Server.Database.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SqlContext _db;
        public OrderRepository(SqlContext db) => _db = db;

        public async Task AddAsync(Order order) => await _db.AddAsync(order);
        public void Remove(Order order) => _db.Remove(order);
        public async Task SaveAsync() => await _db.SaveChangesAsync();
        public IEnumerable<Order> Get() => _db.Ordes;
    }
}