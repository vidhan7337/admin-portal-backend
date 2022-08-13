using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class AboutHospitalRepsository : IAboutHospitalRepository
    {
        private DataContext db;
        private DbSet<AboutHospital> homeSliderModel;
        public AboutHospitalRepsository(DataContext dbcontext)
        {
            db = dbcontext;
            homeSliderModel = db.Set<AboutHospital>();
        }
        public async Task<AboutHospital> AddAboutHospital(AboutHospital user)
        {
            await homeSliderModel.AddAsync(user);
            await db.SaveChangesAsync();
            return user; 
        }

        public async Task DeleteAboutHospital(int id)
        {
            var item = await homeSliderModel.FindAsync(id);
           homeSliderModel.Remove(item);
            await db.SaveChangesAsync();

        }

        public async Task<AboutHospital> GetAboutHospital(int id)
        {
            return await homeSliderModel.FindAsync(id);
        }

        public async Task UpdateAboutHospital(int id, AboutHospital user)
        {
            var slider = await homeSliderModel.FindAsync(id);
            if (slider != null)
            {
                slider.Id = user.Id;
                slider.Description = user.Description;
                slider.Brief = user.Brief;
                slider.MainPoints = user.MainPoints;
                slider.Heading = user.Heading;
                slider.Image = user.Image;


                await db.SaveChangesAsync();
            }
        }
        public List<AboutHospital> GetAll()
        {
            var item = db.AboutHospitals.ToList();
            return item;
        }
    }
}
