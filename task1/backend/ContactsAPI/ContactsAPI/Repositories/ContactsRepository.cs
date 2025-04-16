using ContactsAPI.Database;
using ContactsAPI.Repositories.DTOs;
using ContactsAPI.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Repositories
{
    public interface IContactsRepository
    {
        List<ContactDto> GetAll();
    }

    public class ContactsRepository(ContactsDbContext dbContext) : IContactsRepository
    {
        private readonly ContactsDbContext _dbContext = dbContext;

        public List<ContactDto> GetAll()
        {
            var contacts = _dbContext.Contacts
                .Include(c => c.Category)
                .Include(c => c.Subcategory)
                .ToList();

            return ContactDto.MapToDtos(contacts);
        }
    }
}