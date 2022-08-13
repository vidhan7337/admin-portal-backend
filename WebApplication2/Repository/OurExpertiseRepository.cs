using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Repository
{
    public class OurExpertiseRepsository : IOurExpertiseRepository
    {
        private DataContext db;
        private DbSet<OurExpertise> homeSliderModel;
        public OurExpertiseRepsository(DataContext dbcontext)
        {
            db = dbcontext;
            homeSliderModel = db.Set<OurExpertise>();
        }
        public async Task<OurExpertise> AddOurExpertise(OurExpertise user)
        {
            await homeSliderModel.AddAsync(user);
            await db.SaveChangesAsync();
            return user; 
        }

        public async Task DeleteOurExpertise(int id)
        {
            var item = await homeSliderModel.FindAsync(id);
           homeSliderModel.Remove(item);
            await db.SaveChangesAsync();

        }

        public async Task<OurExpertise> GetOurExpertise(int id)
        {
            return await homeSliderModel.FindAsync(id);
        }

        public async Task UpdateOurExpertise(int id, OurExpertise user)
        {
            var slider = await homeSliderModel.FindAsync(id);
            if (slider != null)
            {
                slider.Id = user.Id;
                slider.Name = user.Name;
                slider.Icon = user.Icon;
                slider.Brief = user.Brief;
                slider.Image = user.Image;


                await db.SaveChangesAsync();
            }
        }
        public List<OurExpertise> GetAll()
        {
            var item = db.OurExperstise.ToList();
            return item;
        }
    }
}

