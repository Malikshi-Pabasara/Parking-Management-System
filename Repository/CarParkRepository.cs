using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkingManagementSystemApi.Data;
using ParkingManagementSystemApi.Models;

namespace ParkingManagementSystemApi.Repository
{
    public class CarParkRepository : ICarParkRepository
    {
        private readonly ParkingContext _context;
        private readonly IMapper _mapper;
        public CarParkRepository(ParkingContext context, IMapper mapper) //Dependency Injection
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CarParkModel>> GetAllCarParksAsync()
        {
            var records = await _context.Parks.ToListAsync();
            return _mapper.Map<List<CarParkModel>>(records); //Auto Map the record
        }

        public async Task<CarParkModel> GetCarParkByIdAsync(int carParkId)
        {
            var park = await _context.Parks.FindAsync(carParkId);
            return _mapper.Map<CarParkModel>(park);
        }

        public async Task<int> AddCarParkAsync(CarParkModel carParkModel)
        {
            var park = new Park()
            {
                Name = carParkModel.Name,
                Latitude = carParkModel.Latitude,
                Longitude = carParkModel.Longitude,
                IsActive = carParkModel.IsActive
            };

            _context.Parks.Add(park);
            await _context.SaveChangesAsync();

            return park.ParkId;
        }
        public async Task UpdateCarParkAsync(int carParkId, CarParkModel carParkModel)
        {
            var park = new Park()
            {
                ParkId = carParkId,
                Name = carParkModel.Name,
                Latitude = carParkModel.Latitude,
                Longitude = carParkModel.Longitude,
                IsActive = carParkModel.IsActive
            };

            _context.Parks.Update(park);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCarParkAsync(int carParkId)
        {
            var park = new Park()
            {
                ParkId = carParkId
            };

            _context.Parks.Remove(park);

            await _context.SaveChangesAsync();
        }
    }
}

