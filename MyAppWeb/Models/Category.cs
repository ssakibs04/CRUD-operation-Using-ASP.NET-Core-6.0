using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyAppWeb.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Display Order")]
        public int DisplayOrder {  get; set; }
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;


    }
}
