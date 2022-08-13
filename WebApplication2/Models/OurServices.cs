using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class OurServices
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50), Required]
        public string Name { get; set; }
        [StringLength(100), Required]
        public string Icon { get; set; }
        [StringLength(500), Required]
        public string ShortDescriptiom { get; set; }
        [StringLength(2000), Required]
        public string LongDescription { get; set; }
        [StringLength(200), Required]
        public string Image { get; set; }
        [StringLength(200), Required]
        public string Tagline { get; set; }
        [StringLength(50), Required]
        public string NextHeading { get; set; }
        [StringLength(2000), Required]
        public string MoreDescription { get; set; }
        [StringLength(200), Required]
        public string Image2 { get; set; }


    }
}
