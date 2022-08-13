using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication2.Models
{
    public class Doctor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(100), Required]
        public string Name { get; set; }
        [StringLength(100), Required]
        public string Designation { get; set; }
        [StringLength(5000), Required]
        public string Biography { get; set; }
        [StringLength(3000), Required]
        public string Education { get; set; }
        [StringLength(2000), Required]
        public string Experience { get; set; }
        [DataType(DataType.EmailAddress), Required]
        public string Email { get; set; }

    }
}
