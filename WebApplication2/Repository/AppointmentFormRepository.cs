using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class AppointmentFormRepsository : IAppointmentFormRepository
    {
        private DataContext db;
        private DbSet<AppointmentForm> homeSliderModel;
        public AppointmentFormRepsository(DataContext dbcontext)
        {
            db = dbcontext;
            homeSliderModel = db.Set<AppointmentForm>();
        }
        public async Task<AppointmentForm> AddAppointmentForm(AppointmentForm user)
        {
            await homeSliderModel.AddAsync(user);
            await db.SaveChangesAsync();
            return user; 
        }

        public async Task DeleteAppointmentForm(int id)
        {
            var item = await homeSliderModel.FindAsync(id);
           homeSliderModel.Remove(item);
            await db.SaveChangesAsync();

        }

        public async Task<AppointmentForm> GetAppointmentForm(int id)
        {
            return await homeSliderModel.FindAsync(id);
        }

        public async Task UpdateAppointmentForm(int id, AppointmentForm user)
        {
            var slider = await homeSliderModel.FindAsync(id);
            if (slider != null)
            {
                slider.Id = user.Id;
                slider.Name = user.Name;
                slider.Email = user.Email;
                slider.Phone = user.Phone;
                slider.Service = user.Service;
                slider.age = user.age;
                slider.Doctor = user.Doctor;


                await db.SaveChangesAsync();
            }
        }
        public List<AppointmentForm> GetAll()
        {
            var item = db.AppointmentForm.ToList();
            return item;
        }
    }
}
