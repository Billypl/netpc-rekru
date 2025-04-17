using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Models.Entities
{
    public class Subcategory
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        public int CategoryId { get; set; }

        // if category value is "business", subcategory should have predefined values
        public bool IsPredefined() => String.Equals(Category.Name.ToLower(), "business");
    }

    public enum ContactSubcategoryType
    {
        None, // private
        FromDictionary, // business
        FreeText // other
    }
}