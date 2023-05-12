using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Equipments
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Equipment Name")]
        public string Name { get; set; }

        [Display(Name = "Price per day")]
        public decimal Price { get; set; }

        [Display(Name = "Equipment Image")]
        public byte[]? Image { get; set; }

        //[NotMapped]
        //[DisplayName("Upload File")]
        //public IFormFile ImageFile { get; set; }
    }
}
