using MyMvcReactApp.Core.UserData.Objects;
using System.Collections.Generic;

namespace MyMvcReactApp.Core.UserData.Services
{
    public interface IUserDataService
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserByEmail(string email);
        Task<User?> GetUserById(int Id);
        Task<bool> AddUserAsync(string name, string email);
    }
}