using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingManagementSystemApi.Models;

namespace ParkingManagementSystemApi.Repository
{
    public interface IParkingRepository
    {
        
        Task<List<ParkingModel>> GetAllParkingAsync();
        Task<ParkingModel> GetParkingByIdAsync(int parkingId);
        Task<int> AddParkingAsync(ParkingModel parkingModel);
        Task UpdateParkingAsync(int parkingId, ParkingModel parkingModel);
        Task DeleteParkingAsync(int parkingId);
    }
}

