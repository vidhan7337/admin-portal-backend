using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class FAQs
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(500), Required]
        public string Question { get; set; }
        [StringLength(1000), Required]
        public string Answer { get; set; }

    }
}
