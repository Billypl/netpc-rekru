using ContactsAPI.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Models.DTOs
{
    public class SubcategoryViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public static SubcategoryViewDto MapToDto(Subcategory subcategory)
        {
            return new SubcategoryViewDto
            {
                Id = subcategory.Id,
                Name = subcategory.Name,
                Category = subcategory.Category.Name
            };
        }
        public static List<SubcategoryViewDto> MapToDtos(IEnumerable<Subcategory> subcategories)
        {
            return subcategories.Select(MapToDto).ToList();
        }
    }

    public class SubcategoryCreateDto
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public static Subcategory MapToEntity(SubcategoryCreateDto dto)
        {
            return new Subcategory
            {
                Name = dto.Name,
                CategoryId = dto.CategoryId
            };
        }
    }

    public class SubcategoryUpdateDto
    {
        public string? Name { get; set; }
        public int? CategoryId { get; set; }

        public static void MapToEntity(SubcategoryUpdateDto dto, Subcategory subcategory)
        {
            subcategory.Name = dto.Name ?? subcategory.Name;
            subcategory.CategoryId = dto.CategoryId ?? subcategory.CategoryId;
        }
    }
}
