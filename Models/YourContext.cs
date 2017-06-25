using Microsoft.EntityFrameworkCore;
 
namespace ECommerce.Models
{
    public class HammyContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public HammyContext(DbContextOptions<HammyContext> options) : base(options) { }
        public DbSet<Hamster> Hamster { get; set; }
    }
}
