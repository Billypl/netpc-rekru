using ContactsAPI.Exceptions;
using ContactsAPI.Models.DTOs;
using ContactsAPI.Repositories;

namespace ContactsAPI.Services
{
    public interface IContactService
    {
        IEnumerable<ContactDto> GetAll();
        ContactDto GetById(int id);
        int Add(CreateContactDto contactDto);
        void Update();
        void Delete();
    }

    public class ContactsService(IContactsRepository contactsRepository) : IContactService
    {
        private readonly IContactsRepository _contactsRepository = contactsRepository;

        public IEnumerable<ContactDto> GetAll()
        {
            var contacts = _contactsRepository.GetAll();
            return ContactDto.MapToDtos(contacts);
        }

        public ContactDto GetById(int id)
        {
            var contact = _contactsRepository.GetById(id);
            if (contact is null)
            {
                throw new NotFoundException("Contact not found");
            }

            return ContactDto.MapToDto(contact);
        }

        public int Add(CreateContactDto contactDto)
        {
            int contactId = _contactsRepository.Add(CreateContactDto.MapToEntity(contactDto));
            return contactId;
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