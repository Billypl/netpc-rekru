using ContactsAPI.Models.Entities;

namespace ContactsAPI.Models.DTOs
{
    public class UpdateContactDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        public int? CategoryId { get; set; }
        public int? SubcategoryId { get; set; }

        public static void MapToEntity(UpdateContactDto dto, Contact contact)
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
