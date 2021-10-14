using System.Collections.Generic;
using System.Threading.Tasks;
using ParkingManagementSystemApi.Models;

namespace ParkingManagementSystemApi.Repository
{
    public interface IVehicleRepository
    {
        Task<List<VehicleModel>> GetAllVehiclesAsync();
        Task<VehicleModel> GetVehicleByIdAsync(int vehicleId);
        Task<int> AddVehicleAsync(VehicleModel vehicleModel);
        Task UpdateVehicleAsync(int vehicleId, VehicleModel vehicleModel);
        Task DeleteVehicleAsync(int vehicleId);

    }
}
