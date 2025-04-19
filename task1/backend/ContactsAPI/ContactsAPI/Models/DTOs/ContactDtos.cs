using ContactsAPI.Models.Entities;

namespace ContactsAPI.Models.DTOs
{
    public class ContactCreateDto
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public int CategoryId { get; set; }
        public int? SubcategoryId { get; set; }

        public static Contact MapToEntity(ContactCreateDto dto)
        {
            return new Contact
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate,
                PhoneNumber = dto.PhoneNumber,
                CategoryId = dto.CategoryId,
                SubcategoryId = dto.SubcategoryId
            };
        }
    }

    public class ContactViewDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Category { get; set; }
        public string? Subcategory { get; set; }

        public static ContactViewDto MapToDto(Contact contact)
        {
            return new ContactViewDto
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

        public static List<ContactViewDto> MapToDtos(IEnumerable<Contact> contacts)
        {
            return contacts.Select(MapToDto).ToList();
        }
    }

    public class ContactUpdateDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        public int? CategoryId { get; set; }
        public int? SubcategoryId { get; set; }

        public static void MapToEntity(ContactUpdateDto dto, Contact contact)
        {
            contact.FirstName = dto.FirstName ?? contact.FirstName;
            contact.LastName = dto.LastName ?? contact.LastName;
            contact.BirthDate = dto.BirthDate ?? contact.BirthDate;
            contact.PhoneNumber = dto.PhoneNumber ?? contact.PhoneNumber;
            contact.CategoryId = dto.CategoryId ?? contact.CategoryId;
            contact.SubcategoryId = dto.SubcategoryId ?? contact.SubcategoryId;
        }
    }
}
