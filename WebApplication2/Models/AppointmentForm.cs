using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class AppointmentForm
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50), Required]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress), Required]
        public string Email { get; set; }
        [Required]

        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        public string Phone { get; set; }
        [StringLength(100), Required]
        public string Service { get; set; }
        [StringLength(100), Required]
        public string Doctor { get; set; }
        [Required]
        public int age { get; set; }



    }
}