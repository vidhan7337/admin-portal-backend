using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class OurServicesRepsository : IOurServicesRepository
    {
        private DataContext db;
        private DbSet<OurServices> homeSliderModel;
        public OurServicesRepsository(DataContext dbcontext)
        {
            db = dbcontext;
            homeSliderModel = db.Set<OurServices>();
        }
        public async Task<OurServices> AddOurServices(OurServices user)
        {
            await homeSliderModel.AddAsync(user);
            await db.SaveChangesAsync();
            return user; 
        }

        public async Task DeleteOurServices(int id)
        {
            var item = await homeSliderModel.FindAsync(id);
           homeSliderModel.Remove(item);
            await db.SaveChangesAsync();

        }

        public async Task<OurServices> GetOurServices(int id)
        {
            return await homeSliderModel.FindAsync(id);
        }

        public async Task UpdateOurServices(int id, OurServices user)
        {
            var slider = await homeSliderModel.FindAsync(id);
            if (slider != null)
            {
                slider.Id = user.Id;
                slider.Name = user.Name;
                slider.Icon = user.Icon;
                slider.ShortDescriptiom = user.ShortDescriptiom;
                slider.LongDescription = user.LongDescription;
                slider.MoreDescription = user.MoreDescription;
                slider.NextHeading = user.NextHeading;
                slider.Image = user.Image;
                slider.Image2 = user.Image2;
                slider.Tagline = user.Tagline;


                await db.SaveChangesAsync();
            }
        }
        public List<OurServices> GetAll()
        {
            var item = db.OurServices.ToList();
            return item;
        }
    }
}

