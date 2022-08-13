using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication2.Data;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class ContactRepsository : IContactRepository
    {
        private DataContext db;
        private DbSet<Contact> homeSliderModel;
        public ContactRepsository(DataContext dbcontext)
        {
            db = dbcontext;
            homeSliderModel = db.Set<Contact>();
        }
        public async Task<Contact> AddContact(Contact user)
        {
            await homeSliderModel.AddAsync(user);
            await db.SaveChangesAsync();
            return user; 
        }

        public async Task DeleteContact(int id)
        {
            var item = await homeSliderModel.FindAsync(id);
           homeSliderModel.Remove(item);
            await db.SaveChangesAsync();

        }

        public async Task<Contact> GetContact(int id)
        {
            return await homeSliderModel.FindAsync(id);
        }

        public async Task UpdateContact(int id, Contact user)
        {
            var slider = await homeSliderModel.FindAsync(id);
            if (slider != null)
            {
                slider.Id = user.Id;
                slider.Address = user.Address;
                slider.Map = user.Map;
                slider.Phone= user.Phone;
                slider.Email= user.Email;


                await db.SaveChangesAsync();
            }
        }
        public List<Contact> GetAll()
        {
            var item = db.Contact.ToList();
            return item;
        }
    }
}

