using ContactsAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Database
{
    public class ContactsDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // todo: Unikalność e-maila
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ContactsDb");
        }
    }
}