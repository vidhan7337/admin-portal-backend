
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class PrivacyPolicyAndTnC
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(5000), Required]
        public string PrivacyPolicy { get; set; }
        [StringLength(5000), Required]
        public string TermsAndCondition { get; set; }

    }
}
