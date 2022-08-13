using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication2.Data;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class DoctorRepsository : IDoctorRepository
    {
        private DataContext db;
        private DbSet<Doctor> homeSliderModel;
        public DoctorRepsository(DataContext dbcontext)
        {
            db = dbcontext;
            homeSliderModel = db.Set<Doctor>();
        }
        public async Task<Doctor> AddDoctor(Doctor user)
        {
            await homeSliderModel.AddAsync(user);
            await db.SaveChangesAsync();
            return user; 
        }

        public async Task DeleteDoctor(int id)
        {
            var item = await homeSliderModel.FindAsync(id);
           homeSliderModel.Remove(item);
            await db.SaveChangesAsync();

        }

        public async Task<Doctor> GetDoctor(int id)
        {
            return await homeSliderModel.FindAsync(id);
        }

        public async Task UpdateDoctor(int id, Doctor user)
        {
            var slider = await homeSliderModel.FindAsync(id);
            if (slider != null)
            {
                slider.Id = user.Id;
                slider.Name = user.Name;
                slider.Designation = user.Designation;
                slider.Education = user.Education;
                slider.Biography = user.Biography;
                slider.Email = user.Email;
                slider.Experience = user.Experience;

                await db.SaveChangesAsync();
            }
        }
        public List<Doctor> GetAll()
        {
            var item = db.Doctor.ToList();
            return item;
        }
    }
}

