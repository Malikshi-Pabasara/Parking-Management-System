using System.Collections.Generic;
using System.Threading.Tasks;
using ParkingManagementSystemApi.Models;

namespace ParkingManagementSystemApi.Repository
{
    public interface ICarParkRepository
    {
        Task<List<CarParkModel>> GetAllCarParksAsync();
        Task<CarParkModel> GetCarParkByIdAsync(int carParkId);
        Task<int> AddCarParkAsync(CarParkModel carParkModel);
        Task UpdateCarParkAsync(int carParkId, CarParkModel carParkModel);
        Task DeleteCarParkAsync(int carParkId);
    }
}
