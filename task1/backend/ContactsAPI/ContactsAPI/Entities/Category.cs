using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(1024)]
        public ContactCategory Type { get; set; }

    }
    public enum ContactCategory
    {
        Private,
        Business,
        Other
    }
}

   