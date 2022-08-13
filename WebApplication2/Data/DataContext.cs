using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<HomeSlider> HomeSlider { get; set; }

        public DbSet<AboutHospital> AboutHospitals { get; set; }
        public DbSet<AppointmentForm> AppointmentForm { get; set; }
        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<FAQs> FAQs { get; set; }
        public DbSet<OurExpertise> OurExperstise { get; set; }
        public DbSet<OurServices> OurServices { get; set; }
        public DbSet<PrivacyPolicyAndTnC> PrivacyPolicyAndTnC { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }
        public DbSet<Video> Video { get; set; }

    }
}
