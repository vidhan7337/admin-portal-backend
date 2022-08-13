using System.Threading.Tasks;
using WebApplication2.Models;
using System.Collections.Generic;
namespace WebApplication2.Repository
{
    public interface IFAQsRepository
    {
        Task<FAQs> AddFAQs(FAQs user);
        Task UpdateFAQs(int id, FAQs user);
        Task DeleteFAQs(int id);
        Task<FAQs> GetFAQs(int id);
        List<FAQs> GetAll();
    }
}
