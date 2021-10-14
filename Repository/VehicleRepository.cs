using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkingManagementSystemApi.Data;
using ParkingManagementSystemApi.Models;

namespace ParkingManagementSystemApi.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ParkingContext _context;
        private readonly IMapper _mapper;
        public VehicleRepository(ParkingContext context, IMapper mapper) //Dependency Injection
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<VehicleModel>> GetAllVehiclesAsync()
        {
            var records = await _context.Vehicles.ToListAsync();
            return _mapper.Map<List<VehicleModel>>(records); //Auto Map the record
        }

        public async Task<VehicleModel> GetVehicleByIdAsync(int vehicleId)
        {
            var vehicle = await _context.Vehicles.FindAsync(vehicleId);
            return _mapper.Map<VehicleModel>(vehicle);
        }

        public async Task<int> AddVehicleAsync(VehicleModel vehicleModel)
        {
            var vehicle = new Vehicle()
            {
                UserId = vehicleModel.UserId,
                VehicleNO = vehicleModel.VehicleNO,
                IsDefault = vehicleModel.IsDefault
            };

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            return vehicle.UserId;
        }
        public async Task UpdateVehicleAsync(int vehicleId, VehicleModel vehicleModel)
        {
            var vehicle = new Vehicle()
            {
                VehicleId = vehicleId,
                UserId = vehicleModel.UserId,
                VehicleNO = vehicleModel.VehicleNO,
                IsDefault = vehicleModel.IsDefault
            };

            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVehicleAsync(int vehicleId)
        {
            var vehicle = new Vehicle()
            {
                VehicleId = vehicleId
            };

            _context.Vehicles.Remove(vehicle);

            await _context.SaveChangesAsync();
        }
    }
}
