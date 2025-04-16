using ContactsAPI.Repositories;
using ContactsAPI.Repositories.DTOs;
using ContactsAPI.Repositories.Entities;

namespace ContactsAPI.Services
{
    public interface IContactService
    {
        IEnumerable<ContactDto> GetAll();
        Contact GetById(int id);
        int Add();
        void Update();
        void Delete();
    }

    public class ContactsService(IContactsRepository contactsRepository) : IContactService
    {
        private readonly IContactsRepository _contactsRepository = contactsRepository;

        public IEnumerable<ContactDto> GetAll()
        {
            return _contactsRepository.GetAll();
        }

        public Contact GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Add()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}