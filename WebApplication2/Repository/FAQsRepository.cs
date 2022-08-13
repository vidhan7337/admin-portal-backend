using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class FAQsRepsository : IFAQsRepository
    {
        private DataContext db;
        private DbSet<FAQs> homeSliderModel;
        public FAQsRepsository(DataContext dbcontext)
        {
            db = dbcontext;
            homeSliderModel = db.Set<FAQs>();
        }
        public async Task<FAQs> AddFAQs(FAQs user)
        {
            await homeSliderModel.AddAsync(user);
            await db.SaveChangesAsync();
            return user; 
        }

        public async Task DeleteFAQs(int id)
        {
            var item = await homeSliderModel.FindAsync(id);
           homeSliderModel.Remove(item);
            await db.SaveChangesAsync();

        }

        public async Task<FAQs> GetFAQs(int id)
        {
            return await homeSliderModel.FindAsync(id);
        }

        public async Task UpdateFAQs(int id, FAQs user)
        {
            var slider = await homeSliderModel.FindAsync(id);
            if (slider != null)
            {
                slider.Id = user.Id;
                slider.Question = user.Question;
                slider.Answer = user.Answer;


                await db.SaveChangesAsync();
            }
        }
        public List<FAQs> GetAll()
        {
            var item = db.FAQs.ToList();
            return item;
        }
    }
}

