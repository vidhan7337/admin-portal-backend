using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Contact
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]

        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress), Required]
        public string Email { get; set; }
        [StringLength(500), Required]
        public string Address { get; set; }
        [StringLength(200), Required]
        public string Map { get; set; }

    }
}
