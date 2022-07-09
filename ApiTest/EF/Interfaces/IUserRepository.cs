using ApiTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTest.EF.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAll();

        Task<User> GetById(int id);
        Task<User> Login(string user, string password);
        Task Delete(int id);

        Task<int?> Add(User user);
        void Update(int id, User user);

    }
}
