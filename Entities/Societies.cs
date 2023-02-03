using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Entities
{
    public class Societies
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Society Name")]
        public string Name { get; set; }
    }
}
