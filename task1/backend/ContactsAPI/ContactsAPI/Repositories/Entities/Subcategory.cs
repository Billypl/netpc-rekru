using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Repositories.Entities
{
    public class Subcategory
    {
        public int Id { get; set; }

        public ContactSubcategoryType Type { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }


        [Required]
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }

    }

    public enum ContactSubcategoryType
    {
        None, // private
        FromDictionary, // buissness
        FreeText // other
    }
}