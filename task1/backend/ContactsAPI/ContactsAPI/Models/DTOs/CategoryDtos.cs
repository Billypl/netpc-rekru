using ContactsAPI.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Models.DTOs
{
    public class CategoryViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static CategoryViewDto MapToDto(Category category)
        {
            return new CategoryViewDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
        public static List<CategoryViewDto> MapToDtos(IEnumerable<Category> categories)
        {
            return categories.Select(MapToDto).ToList();
        }
    }

    public class CategoryCreateDto
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public static Category MapToEntity(CategoryCreateDto dto)
        {
            return new Category
            {
                Name = dto.Name
            };
        }
    }

    public class CategoryUpdateDto
    {
        [Required]
        [MaxLength(128)]
        public string? Name { get; set; }

        public static void MapToEntity(CategoryUpdateDto dto, Category category)
        {
            category.Name = dto.Name ?? category.Name;
        }
    }
}
