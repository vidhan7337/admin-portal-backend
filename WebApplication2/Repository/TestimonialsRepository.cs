using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class TestimonialsRepsository : ITestmonialsRepository
    {
        private DataContext db;
        private DbSet<Testimonials> homeSliderModel;
        public TestimonialsRepsository(DataContext dbcontext)
        {
            db = dbcontext;
            homeSliderModel = db.Set<Testimonials>();
        }
        public async Task<Testimonials> AddTestimonials(Testimonials user)
        {
            await homeSliderModel.AddAsync(user);
            await db.SaveChangesAsync();
            return user; 
        }

        public async Task DeleteTestimonials(int id)
        {
            var item = await homeSliderModel.FindAsync(id);
           homeSliderModel.Remove(item);
            await db.SaveChangesAsync();

        }

        public async Task<Testimonials> GetTestimonials(int id)
        {
            return await homeSliderModel.FindAsync(id);
        }

        public async Task UpdateTestimonials(int id, Testimonials user)
        {
            var slider = await homeSliderModel.FindAsync(id);
            if (slider != null)
            {
                slider.Id = user.Id;
                slider.Name = user.Name;
                slider.Review = user.Review;

                await db.SaveChangesAsync();
            }
        }
        public List<Testimonials> GetAll()
        {
            var item = db.Testimonials.ToList();
            return item;
        }
    }
}

