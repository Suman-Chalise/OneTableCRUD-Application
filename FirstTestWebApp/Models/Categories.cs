using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FirstTestWebApp.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

		[Required]
		public string CategoryDescription { get; set; }

		[Required]

        [DisplayName("Display Order") ]
        [Range(1, 100, ErrorMessage ="Display order must be between 1 - 100")]
		public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
