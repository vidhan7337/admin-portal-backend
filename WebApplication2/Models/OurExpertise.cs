using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class OurExpertise
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50), Required]
        public string Name { get; set; }
        [StringLength(100), Required]
        public string Icon { get; set; }
        [StringLength(500), Required]
        public string Brief { get; set; }
        [StringLength(200), Required]
        public string Image { get; set; }

    }
}