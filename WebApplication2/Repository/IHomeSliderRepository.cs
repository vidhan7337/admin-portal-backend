using System.Threading.Tasks;
using WebApplication2.Models;
using System.Collections.Generic;

namespace WebApplication2.Repository
{
    public interface IHomeSliderRepository
    {
        Task<HomeSlider> AddHomeSlider(HomeSlider user);
        Task UpdateHomeSlider(int id, HomeSlider user);
        Task DeleteHomeSlider(int id);
        Task<HomeSlider> GetHomeSlider(int id);
        List<HomeSlider> GetAll();
    }
}
