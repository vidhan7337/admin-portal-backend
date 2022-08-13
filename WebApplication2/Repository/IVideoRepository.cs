using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Models;
namespace WebApplication2.Repository
{
    public interface IVideoRepository
    {
        Task<Video> AddVideo(Video user);
        Task UpdateVideo(int id, Video user);
        Task DeleteVideo(int id);
        Task<Video> GetVideo(int id);
        List<Video> GetAll();
    }
}
