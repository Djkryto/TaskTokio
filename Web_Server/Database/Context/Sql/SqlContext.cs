using Web_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Web_Server.Database.Context.Sql
{
    public class SqlContext : DbContext
    {
        public DbSet<Order> Ordes { get; set; }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) => Database.EnsureCreated();
    }
}
