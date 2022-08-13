using System.Threading.Tasks;
using WebApplication2.Models;
using System.Collections.Generic;
namespace WebApplication2.Repository
{
    public interface IDepartmentsRepository
    {
        Task<Departments> AddDepartments(Departments user);
        Task UpdateDepartments(int id, Departments user);
        Task DeleteDepartments(int id);
        Task<Departments> GetDepartments(int id);
        List<Departments> GetAll();
    }
}
