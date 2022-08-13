using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class VideoRepsository : IVideoRepository
    {
        private DataContext db;
        private DbSet<Video> homeSliderModel;
        public VideoRepsository(DataContext dbcontext)
        {
            db = dbcontext;
            homeSliderModel = db.Set<Video>();
        }
        public async Task<Video> AddVideo(Video user)
        {
            await homeSliderModel.AddAsync(user);
            await db.SaveChangesAsync();
            return user; 
        }

        public async Task DeleteVideo(int id)
        {
            var item = await homeSliderModel.FindAsync(id);
           homeSliderModel.Remove(item);
            await db.SaveChangesAsync();

        }

        public async Task<Video> GetVideo(int id)
        {
            return await homeSliderModel.FindAsync(id);
        }

        public async Task UpdateVideo(int id, Video user)
        {
            var slider = await homeSliderModel.FindAsync(id);
            if (slider != null)
            {
                slider.Id = user.Id;
                slider.Description = user.Description;
                slider.Title=user.Title;
                slider.VideoLink = user.VideoLink;
                slider.Department = user.Department;


                await db.SaveChangesAsync();
            }
        }
        public List<Video> GetAll()
        {
            var item = db.Video.ToList();
            return item;
        }
    }
}

