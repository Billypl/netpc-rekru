using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Repositories.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(1024)]
        public ContactCategoryType Type { get; set; }

    }
    public enum ContactCategoryType
    {
        Private,
        Business,
        Other
    }
}

   