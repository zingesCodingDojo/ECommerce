using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
 
namespace ECommerce.Models
{
    public class HammyContext : IdentityDbContext
    {
        public HammyContext(DbContextOptions<HammyContext> options) : base(options) { }
        public DbSet<Hamster> Hamster { get; set; }
        public DbSet<HammyBlog> HammyBlog { get; set; }
        public DbSet<BlogLike> BlogLike { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Goodie> Goodie { get; set; }
        public DbSet<HammyWishList> HammyWishList { get; set; }
    }
}
