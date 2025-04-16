using ContactsAPI.Database;
using ContactsAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Repositories
{
    public interface IContactsRepository
    {
        List<Contact> GetAll();
    }

    public class ContactsRepository(ContactsDbContext dbContext) : IContactsRepository
    {
        private readonly ContactsDbContext _dbContext = dbContext;

        public List<Contact> GetAll()
        {
            return _dbContext.Contacts
                .Include(c => c.Category)
                .Include(c => c.Subcategory)
                .ToList();
        }
    }
}