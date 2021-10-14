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
    public class SlotRepository : ISlotRepository
    {
        private readonly ParkingContext _context;
        private readonly IMapper _mapper;
        public SlotRepository(ParkingContext context, IMapper mapper) //Dependency Injection
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SlotModel>> GetAllSlotsAsync()
        {
            var records = await _context.Slots.ToListAsync();
            return _mapper.Map<List<SlotModel>>(records); //Auto Map the record
        }

        public async Task<SlotModel> GetSlotByIdAsync(int slotId)
        {
            var slot = await _context.Slots.FindAsync(slotId);
            return _mapper.Map<SlotModel>(slot);
        }

        public async Task<int> AddSlotAsync(SlotModel slotModel)
        {
            var slot = new Slot()
            {
                ParkId = slotModel.ParkId,
                CurrentVehicleNo = slotModel.CurrentVehicleNo,
                Status = slotModel.Status,
                SlotNo = slotModel.SlotNo,
                IsActive = slotModel.IsActive
            };

            _context.Slots.Add(slot);
            await _context.SaveChangesAsync();

            return slot.SlotId;
        }
        public async Task UpdateSlotAsync(int slotId, SlotModel slotModel)
        {
            var slot = new Slot()
            {
                SlotId = slotId,
                ParkId = slotModel.ParkId,
                CurrentVehicleNo = slotModel.CurrentVehicleNo,
                Status = slotModel.Status,
                SlotNo = slotModel.SlotNo,
                IsActive = slotModel.IsActive
            };

            _context.Slots.Update(slot);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSlotAsync(int slotId)
        {
            var slot = new Slot()
            {
                SlotId = slotId
            };

            _context.Slots.Remove(slot);

            await _context.SaveChangesAsync();
        }
    }
}
