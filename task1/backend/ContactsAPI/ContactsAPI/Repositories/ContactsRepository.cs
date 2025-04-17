using ContactsAPI.Database;
using ContactsAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Repositories
{
    public interface IContactsRepository
    {
        List<Contact> GetAll();
        Contact GetById(int id);
        int Add(Contact contact);
        void Delete(Contact contact);
        void SaveChanges();

    }

    public class ContactsRepository(ContactsDbContext dbContext) : IContactsRepository
    {
        private readonly ContactsDbContext _dbContext = dbContext;

        public List<Contact> GetAll()
        {
            var contacts = _dbContext.Contacts
                .Include(c => c.Category)
                .Include(c => c.Subcategory)
                .ToList();
            return contacts;
        }

        public Contact GetById(int id)
        {
            var contact = _dbContext.Contacts
                .Include(c => c.Category)
                .Include(c => c.Subcategory)
                .FirstOrDefault(c => id == c.Id);
            return contact;
        }

        public int Add(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
            return contact.Id;
        }

        public void Delete(Contact contact)
        {
            _dbContext.Contacts.Remove(contact);
            _dbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}