using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Models;
namespace WebApplication2.Repository
{
    public interface IContactRepository
    {
        Task<Contact> AddContact(Contact user);
        Task UpdateContact(int id, Contact user);
        Task DeleteContact(int id);
        Task<Contact> GetContact(int id);

        List<Contact> GetAll();
    }
}
