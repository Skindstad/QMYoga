using Microsoft.EntityFrameworkCore;
using QMYoga.Configuration;

namespace QMYoga.Models
{
    [EntityTypeConfiguration(typeof(ItemConfiguration))]
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
