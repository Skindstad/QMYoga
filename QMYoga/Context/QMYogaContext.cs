using Microsoft.EntityFrameworkCore;
using QMYoga.Models;

namespace QMYoga.Context
{
    public class QMYogaContext(DbContextOptions<QMYogaContext> options) : DbContext(options)
    {
        public DbSet<Item> Items { get; set; }
    }
}
