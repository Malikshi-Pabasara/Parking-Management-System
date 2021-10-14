using System.Collections.Generic;
using System.Threading.Tasks;
using ParkingManagementSystemApi.Models;

namespace ParkingManagementSystemApi.Repository
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByIdAsync(int userId);
        Task<int> AddUserAsync(UserModel userModel);
        Task UpdateUserAsync(int userId, UserModel userModel);
        Task DeleteUserAsync(int userId);
    }
}
