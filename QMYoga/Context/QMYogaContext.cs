using Microsoft.EntityFrameworkCore;
using QMYoga.Models;

namespace QMYoga.Context
{
    public class QMYogaContext(DbContextOptions<QMYogaContext> options) : DbContext(options)
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Video> Videos { get; set; }
    }
}
