using ContactsAPI.Exceptions;
using ContactsAPI.Models.DTOs;
using ContactsAPI.Models.Entities;
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
            var contact = GetContactById(id);
            return ViewContactDto.MapToDto(contact);
        }

        public int Add(CreateContactDto contactDto)
        {
            int contactId = _contactsRepository.Add(CreateContactDto.MapToEntity(contactDto));
            return contactId;
        }

        public void Update(int id, UpdateContactDto dto)
        {
            var contact = GetContactById(id);
            UpdateContactDto.MapToEntity(dto, contact);
            _contactsRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            var contact = GetContactById(id);
            _contactsRepository.Delete(contact);
        }

        private Contact GetContactById(int id)
        {
            var contact = _contactsRepository.GetById(id);
            if (contact is null)
            {
                throw new NotFoundException($"Contact with id {id} not found");
            }
            return contact;
        }
    }
}