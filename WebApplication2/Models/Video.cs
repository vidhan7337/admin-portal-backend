using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Video
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50), Required]
        public string Title { get; set; }
        [StringLength(200), Required]
        public string VideoLink { get; set; }
        [StringLength(500), Required]
        public string Description { get; set; }
        [StringLength(100), Required]
        public string Department { get; set; }

    }
}
