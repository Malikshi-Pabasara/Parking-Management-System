using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkingManagementSystemApi.Data;
using ParkingManagementSystemApi.Models;

namespace ParkingManagementSystemApi.Repository
{
    public class ParkingRepository : IParkingRepository
    {
        private readonly ParkingContext _context;
        private readonly IMapper _mapper;
        public ParkingRepository(ParkingContext context, IMapper mapper) //Dependency Injection
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ParkingModel>> GetAllParkingAsync()
        {
            var records = await _context.Parking.ToListAsync();
            return _mapper.Map<List<ParkingModel>>(records); //Auto Map the record
        }

        public async Task<ParkingModel> GetParkingByIdAsync(int parkingId)
        {
            var parking = await _context.Parking.FindAsync(parkingId);
            return _mapper.Map<ParkingModel>(parking);
        }

        public async Task<int> AddParkingAsync(ParkingModel parkingModel)
        {
            var parking = new CarParking()
            {
                StartTime = parkingModel.StartTime,
                EndTime = parkingModel.EndTime,
                Date = parkingModel.Date,
                VehicleId = parkingModel.VehicleId,
                SlotId = parkingModel.SlotId
            };

            _context.Parking.Add(parking);
            await _context.SaveChangesAsync();

            return parking.Id;
        }
        public async Task UpdateParkingAsync(int parkingId, ParkingModel parkingModel)
        {
            var parking = new CarParking()
            {
                Id = parkingId,
                StartTime = parkingModel.StartTime,
                EndTime = parkingModel.EndTime,
                Date = parkingModel.Date,
                VehicleId = parkingModel.VehicleId,
                SlotId = parkingModel.SlotId
            };

            _context.Parking.Update(parking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteParkingAsync(int parkingId)
        {
            var parking = new CarParking()
            {
               Id = parkingId
            };

            _context.Parking.Remove(parking);

            await _context.SaveChangesAsync();
        }
    }
}


