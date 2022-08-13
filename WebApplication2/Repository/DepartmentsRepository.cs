using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication2.Data;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class DepartmentsRepsository : IDepartmentsRepository
    {
        private DataContext db;
        private DbSet<Departments> homeSliderModel;
        public DepartmentsRepsository(DataContext dbcontext)
        {
            db = dbcontext;
            homeSliderModel = db.Set<Departments>();
        }
        public async Task<Departments> AddDepartments(Departments user)
        {
            await homeSliderModel.AddAsync(user);
            await db.SaveChangesAsync();
            return user; 
        }

        public async Task DeleteDepartments(int id)
        {
            var item = await homeSliderModel.FindAsync(id);
           homeSliderModel.Remove(item);
            await db.SaveChangesAsync();

        }

        public async Task<Departments> GetDepartments(int id)
        {
            return await homeSliderModel.FindAsync(id);
        }

        public async Task UpdateDepartments(int id, Departments user)
        {
            var slider = await homeSliderModel.FindAsync(id);
            if (slider != null)
            {
                slider.Id = user.Id;
                slider.Name = user.Name;
                slider.Brief = user.Brief;


                await db.SaveChangesAsync();
            }
        }
        public List<Departments> GetAll()
        {
            var item = db.Departments.ToList();
            return item;
        }
    }
}

