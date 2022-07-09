using ClientMVC.Common.Dto;
using ClientMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Services
{
    public interface IUserService
    {
        Task<List<UserModel>> Get();
        Task<UserModel> Get(int id);
        Task<int> Add(UserModel user);
        Task<bool> Delete(int id);
        Task<int> Update(int usserId, UserModel user);
        Task<UserModel> Login(LoginDto model);
    }
}
