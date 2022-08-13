using System.Threading.Tasks;
using WebApplication2.Models;
using System.Collections.Generic;
namespace WebApplication2.Repository
{
    public interface IDoctorRepository
    {
        Task<Doctor> AddDoctor(Doctor user);
        Task UpdateDoctor(int id, Doctor user);
        Task DeleteDoctor(int id);
        Task<Doctor> GetDoctor(int id);
        List<Doctor> GetAll();
    }
}
