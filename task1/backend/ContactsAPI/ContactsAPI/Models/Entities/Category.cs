using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

    }
    public enum ContactCategoryType
    {
        Private,
        Business,
        Other
    }
}

   