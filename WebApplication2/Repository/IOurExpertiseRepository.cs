using System.Threading.Tasks;
using WebApplication2.Models;
using System.Collections.Generic;
namespace WebApplication2.Repository
{
    public interface IOurExpertiseRepository
    {
        Task<OurExpertise> AddOurExpertise(OurExpertise user);
        Task UpdateOurExpertise(int id, OurExpertise user);
        Task DeleteOurExpertise(int id);
        Task<OurExpertise> GetOurExpertise(int id);
        List<OurExpertise> GetAll();
    }
}
