using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Models;
namespace WebApplication2.Repository
{
    public interface IAppointmentFormRepository
    {
        Task<AppointmentForm> AddAppointmentForm(AppointmentForm user);
        Task UpdateAppointmentForm(int id, AppointmentForm user);
        Task DeleteAppointmentForm(int id);
        Task<AppointmentForm> GetAppointmentForm(int id);
        List<AppointmentForm> GetAll();
    }
}
