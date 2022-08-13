using System.Threading.Tasks;
using WebApplication2.Models;
using System.Collections.Generic;
namespace WebApplication2.Repository
{
    public interface IOurServicesRepository
    {
        Task<OurServices> AddOurServices(OurServices user);
        Task UpdateOurServices(int id, OurServices user);
        Task DeleteOurServices(int id);
        Task<OurServices> GetOurServices(int id);
        List<OurServices> GetAll();
    }
}
