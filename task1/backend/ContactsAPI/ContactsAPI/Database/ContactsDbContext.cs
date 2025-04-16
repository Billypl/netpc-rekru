using ContactsAPI.Entities;
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
            modelBuilder.Entity<Subcategory>()
                .Property(s => s.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Category>()
                .Property(c => c.Type)
                .HasConversion<string>();

            // todo: Unikalność e-maila

            // relacja Contact -> Category
            //modelBuilder.Entity<Contact>()
            //    .HasOne(c => c.Category)
            //    .WithMany(cat => cat.Contacts)
            //    .HasForeignKey(c => c.CategoryId);

            //// relacja Contact -> Subcategory (opcjonalna)
            //modelBuilder.Entity<Contact>()
            //    .HasOne(c => c.Subcategory)
            //    .WithMany(sub => sub.Contacts)
            //    .HasForeignKey(c => c.SubcategoryId)
            //    .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ContactsDb");
        }
    }
}