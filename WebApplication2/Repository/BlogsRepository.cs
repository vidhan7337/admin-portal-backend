using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication2.Data;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class BlogsRepsository : IBlogsRepository
    {
        private DataContext db;
        private DbSet<Blogs> homeSliderModel;
        public BlogsRepsository(DataContext dbcontext)
        {
            db = dbcontext;
            homeSliderModel = db.Set<Blogs>();
        }
        public async Task<Blogs> AddBlogs(Blogs user)
        {
            await homeSliderModel.AddAsync(user);
            await db.SaveChangesAsync();
            return user; 
        }

        public async Task DeleteBlogs(int id)
        {
            var item = await homeSliderModel.FindAsync(id);
           homeSliderModel.Remove(item);
            await db.SaveChangesAsync();

        }

        public async Task<Blogs> GetBlogs(int id)
        {
            return await homeSliderModel.FindAsync(id);
        }

        public async Task UpdateBlogs(int id, Blogs user)
        {
            var slider = await homeSliderModel.FindAsync(id);
            if (slider != null)
            {
                slider.Id = user.Id;
                slider.Title = user.Title;
                slider.Content = user.Content;
                slider.Brief = user.Brief;
                slider.Image = user.Image;


                await db.SaveChangesAsync();
            }
        }
        public List<Blogs> GetAll()
        {
            var item = db.Blogs.ToList();
            return item;
        }
    }
}

