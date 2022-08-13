using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class HomeSliderRepsository : IHomeSliderRepository
    {
        private DataContext db;
        private DbSet<HomeSlider> homeSliderModel;
        public HomeSliderRepsository(DataContext dbcontext)
        {
            db = dbcontext;
            homeSliderModel = db.Set<HomeSlider>();
        }
        public async Task<HomeSlider> AddHomeSlider(HomeSlider user)
        {
            await homeSliderModel.AddAsync(user);
            await db.SaveChangesAsync();
            return user; 
        }

        public async Task DeleteHomeSlider(int id)
        {
            var item = await homeSliderModel.FindAsync(id);
           homeSliderModel.Remove(item);
            await db.SaveChangesAsync();

        }

        public async Task<HomeSlider> GetHomeSlider(int id)
        {
            return await homeSliderModel.FindAsync(id);
        }

        public async Task UpdateHomeSlider(int id, HomeSlider user)
        {
            var slider = await homeSliderModel.FindAsync(id);
            if (slider != null)
            {
                slider.Id = user.Id;
                slider.Description = user.Description;
                slider.Title=user.Title;
                slider.ButtonLink = user.ButtonLink;
                slider.ButtonName=user.ButtonName;
                slider.Image = user.Image;


                await db.SaveChangesAsync();
            }
        }
        public List<HomeSlider> GetAll()
        {
            var item = db.HomeSlider.ToList();
            return item;
        }
    }
}

