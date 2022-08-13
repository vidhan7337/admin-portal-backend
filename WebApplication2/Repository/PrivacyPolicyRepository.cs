using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication2.Data;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class PrivacyPolicyRepsository : IPrivacyPolicyRepository
    {
        private DataContext db;
        private DbSet<PrivacyPolicyAndTnC> homeSliderModel;
        public PrivacyPolicyRepsository(DataContext dbcontext)
        {
            db = dbcontext;
            homeSliderModel = db.Set<PrivacyPolicyAndTnC>();
        }
        public async Task<PrivacyPolicyAndTnC> AddPrivacyPolicyAndTnC(PrivacyPolicyAndTnC user)
        {
            await homeSliderModel.AddAsync(user);
            await db.SaveChangesAsync();
            return user; 
        }

        public async Task DeletePrivacyPolicyAndTnC(int id)
        {
            var item = await homeSliderModel.FindAsync(id);
           homeSliderModel.Remove(item);
            await db.SaveChangesAsync();

        }

        public async Task<PrivacyPolicyAndTnC> GetPrivacyPolicyAndTnC(int id)
        {
            return await homeSliderModel.FindAsync(id);
        }

        public async Task UpdatePrivacyPolicyAndTnC(int id, PrivacyPolicyAndTnC user)
        {
            var slider = await homeSliderModel.FindAsync(id);
            if (slider != null)
            {
                slider.Id = user.Id;
                slider.PrivacyPolicy = user.PrivacyPolicy;
                slider.TermsAndCondition = user.TermsAndCondition;


                await db.SaveChangesAsync();
            }
        }
        public List<PrivacyPolicyAndTnC> GetAll()
        {
            var item = db.PrivacyPolicyAndTnC.ToList();
            return item;
        }
    }
}

