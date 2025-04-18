using ContactsAPI.Database;
using ContactsAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Repositories
{
    public interface ICategoriesRepository
    {
        List<Category> GetAll();
        Category? GetById(int id);
        int Add(Category category);
        void Delete(Category category);
        void SaveChanges();
    }

    public class CategoriesRepository(ContactsDbContext dbContext) : ICategoriesRepository
    {
        private readonly ContactsDbContext _dbContext = dbContext;


        public List<Category> GetAll()
        {
            var categories = _dbContext.Categories
                .ToList();
            return categories;
        }

        public Category? GetById(int id)
        {
            var category = _dbContext.Categories
                .FirstOrDefault(c => id == c.Id);
            return category;
        }

        public int Add(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return category.Id;
        }

        public void Delete(Category category)
        {
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
