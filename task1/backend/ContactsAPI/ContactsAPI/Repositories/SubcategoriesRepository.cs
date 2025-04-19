using ContactsAPI.Database;
using ContactsAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Repositories
{
    public interface ISubcategoriesRepository
    {
        List<Subcategory> GetAll();
        Subcategory? GetById(int id);
        int Add(Subcategory subcategory);
        void Delete(Subcategory subcategory);
        void SaveChanges();
    }

    internal class SubcategoriesRepository(ContactsDbContext dbContext) : ISubcategoriesRepository
    {
        private readonly ContactsDbContext _dbContext = dbContext;

        public List<Subcategory> GetAll()
        {
            var subcategory = _dbContext.Subcategories
                .Include(s => s.Category)
                .ToList();
            return subcategory;
        }

        public Subcategory? GetById(int id)
        {
            var subcategory = _dbContext.Subcategories
                .Include(s => s.Category)
                .FirstOrDefault(s => id == s.Id);
            return subcategory;
        }

        public int Add(Subcategory subcategory)
        {
            _dbContext.Subcategories.Add(subcategory);
            _dbContext.SaveChanges();
            return subcategory.Id;
        }

        public void Delete(Subcategory subcategory)
        {
            _dbContext.Subcategories.Remove(subcategory);
            _dbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}