using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class AboutHospital
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50), Required]
        public string Heading { get; set; }
        [StringLength(500), Required]
        public string Brief { get; set; }
        [StringLength(500), Required]
        public string MainPoints { get; set; }
        [StringLength(3000), Required]
        public string Description { get; set; }
        [StringLength(200), Required]
        public string Image { get; set; }

    }
}
