using ContactsAPI.Exceptions;
using ContactsAPI.Models.DTOs;
using ContactsAPI.Models.Entities;
using ContactsAPI.Repositories;

namespace ContactsAPI.Services
{
    public interface IContactService
    {
        IEnumerable<ContactViewDto> GetAll();
        ContactViewDto GetById(int id);
        int Add(ContactCreateDto dto);
        void Update(int id, ContactUpdateDto dto);
        void Delete(int id);
    }

    public class ContactsService(IContactsRepository contactsRepository) : IContactService
    {
        private readonly IContactsRepository _contactsRepository = contactsRepository;

        public IEnumerable<ContactViewDto> GetAll()
        {
            var contacts = _contactsRepository.GetAll();
            return ContactViewDto.MapToDtos(contacts);
        }

        public ContactViewDto GetById(int id)
        {
            var contact = GetContactById(id);
            return ContactViewDto.MapToDto(contact);
        }

        public int Add(ContactCreateDto dto)
        {
            int contactId = _contactsRepository.Add(ContactCreateDto.MapToEntity(dto));
            return contactId;
        }

        public void Update(int id, ContactUpdateDto dto)
        {
            var contact = GetContactById(id);
            ContactUpdateDto.MapToEntity(dto, contact);
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