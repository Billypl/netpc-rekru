using ContactsAPI.Models.Entities;

namespace ContactsAPI.Models.DTOs
{
    public class CreateContactDto
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public int CategoryId { get; set; }
        public int? SubcategoryId { get; set; }

        public static Contact MapToEntity(CreateContactDto dto)
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

        // create json string based on createcontactdto with example data





    }
}
