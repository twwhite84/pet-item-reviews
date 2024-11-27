using Microsoft.EntityFrameworkCore;

namespace PetItemReviews.Models
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) : base(options) { }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "Fo", Name = "Food" },
                new Category { CategoryId = "Tr", Name = "Treats" },
                new Category { CategoryId = "Ty", Name = "Toys" },
                new Category { CategoryId = "Le", Name = "Leashes" },
                new Category { CategoryId = "Me", Name = "Medicine" }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    ItemId = 1,
                    Name = "6ft Dog Lead",
                    CategoryId = "Le",
                    Rating = 4
                }
            );
        }
    }
}
