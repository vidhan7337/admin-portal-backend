using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Models;
namespace WebApplication2.Repository
{
    public interface IAboutHospitalRepository
    {
        Task<AboutHospital> AddAboutHospital(AboutHospital user);
        Task UpdateAboutHospital(int id, AboutHospital user);
        Task DeleteAboutHospital(int id);
        Task<AboutHospital> GetAboutHospital(int id);
        List<AboutHospital> GetAll();
    }
}
