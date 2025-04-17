using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Models.Entities
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [Phone]
        [MaxLength(16)]
        public string PhoneNumber { get; set; }


        [Required]
        public virtual Category Category { get; set; }

        public int CategoryId { get; set; }


        public virtual Subcategory? Subcategory { get; set; } // buisness -> boss, client // other -> type in

        public int? SubcategoryId { get; set; } // nullable for non-business categories

        // todo: owner?
    }
}