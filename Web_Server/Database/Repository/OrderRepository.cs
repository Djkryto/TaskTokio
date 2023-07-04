using Web_Server.Database.Context.Sql;
using Web_Server.Appliaction;
using Web_Server.Models;

namespace Web_Server.Database.Repository
{
    ///<inheritdoc />
    public class OrderRepository : IOrderRepository
    {
        private readonly SqlContext _db;

        /// <summary>
        /// .ctor.
        /// </summary>
        /// <param name="db">Модель базы данных.</param>
        public OrderRepository(SqlContext db) => _db = db;

        ///<inheritdoc />
        public async Task AddAsync(Order order) => await _db.AddAsync(order);

        ///<inheritdoc />
        public void Remove(Order order) => _db.Remove(order);

        ///<inheritdoc />
        public async Task SaveAsync() => await _db.SaveChangesAsync();

        ///<inheritdoc />
        public IEnumerable<Order> Get() => _db.Ordes;
    }
}