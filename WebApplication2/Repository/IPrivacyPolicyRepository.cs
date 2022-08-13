using System.Threading.Tasks;
using WebApplication2.Models;
using System.Collections.Generic;
namespace WebApplication2.Repository
{
    public interface IPrivacyPolicyRepository
    {
        Task<PrivacyPolicyAndTnC> AddPrivacyPolicyAndTnC(PrivacyPolicyAndTnC user);
        Task UpdatePrivacyPolicyAndTnC(int id, PrivacyPolicyAndTnC user);
        Task DeletePrivacyPolicyAndTnC(int id);
        Task<PrivacyPolicyAndTnC> GetPrivacyPolicyAndTnC(int id);
        List<PrivacyPolicyAndTnC> GetAll();
    }
}
