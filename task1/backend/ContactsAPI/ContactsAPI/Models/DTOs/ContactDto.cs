using ContactsAPI.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Models.DTOs
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Category { get; set; }
        public string? Subcategory { get; set; }

        public static ContactDto MapToDto(Contact contact)
        {
            return new ContactDto
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                BirthDate = contact.BirthDate,
                PhoneNumber = contact.PhoneNumber,
                Category = contact.Category.Name,
                Subcategory = contact.Subcategory?.Name
            };
        }

        public static List<ContactDto> MapToDtos(IEnumerable<Contact> contacts)
        {
            return contacts.Select(MapToDto).ToList();
        }
    }
}