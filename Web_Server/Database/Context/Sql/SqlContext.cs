using Microsoft.EntityFrameworkCore;
using Web_Server.Models;

namespace Web_Server.Database.Context.Sql
{
    /// <summary>
    /// Класс отвещающий за создание и обращение к базе данных.
    /// </summary>
    public class SqlContext : DbContext
    {
        /// <summary>
        /// Таблица заказов.
        /// </summary>
        public DbSet<Order> Ordes { get; set; }

        /// <summary>
        /// .ctor
        /// </summary>
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) => Database.EnsureCreated();
    }
}
