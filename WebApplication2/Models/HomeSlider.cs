using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("HomeSlider")]
    public class HomeSlider
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50), Required]
        public string Title { get; set; }

        [StringLength(200), Required]
        public string Description { get; set; }
        [StringLength(200), Required]
        public string Image { get; set; }
        [StringLength(50), Required]
        public string ButtonName { get; set; }
        [StringLength(50), Required]
        public string ButtonLink { get; set; }

    }
}
