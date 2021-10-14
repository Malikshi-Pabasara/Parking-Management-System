using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkingManagementSystemApi.Data;
using ParkingManagementSystemApi.Models;

namespace ParkingManagementSystemApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ParkingContext _context;
        private readonly IMapper _mapper;
        public UserRepository(ParkingContext context, IMapper mapper) //Dependency Injection
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            var records = await _context.Users.ToListAsync();
            return _mapper.Map<List<UserModel>>(records); //Auto Map the record
        }

        public async Task<UserModel> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            return _mapper.Map<UserModel>(user);
        }

        public async Task<int> AddUserAsync(UserModel userModel)
        {
            var user = new User()
            {
                Name = userModel.Name,
                PhoneNo = userModel.PhoneNo,
                Email = userModel.Email,
                NumberOfReport = userModel.NumberOfReport
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user.UserId;
        }
        public async Task UpdateUserAsync(int userId, UserModel userModel)
        {
            var user = new User()
            {
                UserId = userId,
                Name = userModel.Name,
                PhoneNo = userModel.PhoneNo,
                Email = userModel.Email,
                NumberOfReport = userModel.NumberOfReport
            };

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = new User() 
            { 
                UserId = userId 
            };

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }
    }
}
