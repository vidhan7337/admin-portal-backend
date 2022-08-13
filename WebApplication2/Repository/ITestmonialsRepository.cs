using System.Threading.Tasks;
using WebApplication2.Models;
using System.Collections.Generic;
namespace WebApplication2.Repository
{
    public interface ITestmonialsRepository
    {
    Task<Testimonials> AddTestimonials(Testimonials user);
        Task UpdateTestimonials(int id, Testimonials user);
        Task DeleteTestimonials(int id);
        Task<Testimonials> GetTestimonials(int id);
        List<Testimonials> GetAll();
    }
}
