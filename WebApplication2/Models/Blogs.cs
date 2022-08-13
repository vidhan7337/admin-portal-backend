using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Blogs
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(200), Required]
        public string Title { get; set; }
        [StringLength(200), Required]
        public string Image { get; set; }
        [StringLength(500), Required]
        public string Brief { get; set; }
        [StringLength(8000), Required]
        public string Content { get; set; }

    }
}
