using ContactsAPI.Exceptions;
using ContactsAPI.Models.DTOs;
using ContactsAPI.Repositories;

namespace ContactsAPI.Services
{
    public interface IContactService
    {
        IEnumerable<ViewContactDto> GetAll();
        ViewContactDto GetById(int id);
        int Add(CreateContactDto contactDto);
        void Update(int id, UpdateContactDto dto);
        void Delete(int id);
    }

    public class ContactsService(IContactsRepository contactsRepository) : IContactService
    {
        private readonly IContactsRepository _contactsRepository = contactsRepository;

        public IEnumerable<ViewContactDto> GetAll()
        {
            var contacts = _contactsRepository.GetAll();
            return ViewContactDto.MapToDtos(contacts);
        }

        public ViewContactDto GetById(int id)
        {
            var contact = _contactsRepository.GetById(id);
            if (contact is null)
            {
                throw new NotFoundException("Contact not found");
            }

            return ViewContactDto.MapToDto(contact);
        }

        public int Add(CreateContactDto contactDto)
        {
            int contactId = _contactsRepository.Add(CreateContactDto.MapToEntity(contactDto));
            return contactId;
        }

        public void Update(int id, UpdateContactDto dto)
        {
            var contact = _contactsRepository.GetById(id);
            if (contact is null)
            {
                throw new NotFoundException("Contact not found");
            }
            UpdateContactDto.MapToEntity(dto, contact);
            _contactsRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            var contact = _contactsRepository.GetById(id);
            if (contact is null)
            {
                throw new NotFoundException("Contact not found");
            }
            _contactsRepository.Delete(contact);
        }
    }
}