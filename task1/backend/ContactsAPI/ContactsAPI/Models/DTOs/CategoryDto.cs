using ContactsAPI.Models.Entities;

namespace ContactsAPI.Models.DTOs
{
    public class CategoryDto
    {
        public string Name { get; set; }

        public static Category MapToEntity(CategoryDto dto)
        {
            return new Category
            {
                Name = dto.Name
            };
        }
    }
}
