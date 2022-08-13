using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Models;
namespace WebApplication2.Repository
{
    public interface IBlogsRepository
    {
        Task<Blogs> AddBlogs(Blogs user);
        Task UpdateBlogs(int id, Blogs user);
        Task DeleteBlogs(int id);
        Task<Blogs> GetBlogs(int id);
        List<Blogs> GetAll();
    }
}
