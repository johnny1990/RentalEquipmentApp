using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Entities
{
    public class Rentals
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Rental date")]
        public DateTime? Date { get; set; }

        [Display(Name = "Rental date")]
        public int SocietyId { get; set; }
        public  Societies Societies { get; set; }

   
    }
}
