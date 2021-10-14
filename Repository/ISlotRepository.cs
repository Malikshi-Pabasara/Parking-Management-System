using System.Collections.Generic;
using System.Threading.Tasks;
using ParkingManagementSystemApi.Models;

namespace ParkingManagementSystemApi.Repository
{
    public interface ISlotRepository
    {
        Task<List<SlotModel>> GetAllSlotsAsync();
        Task<SlotModel> GetSlotByIdAsync(int slotId);
        Task<int> AddSlotAsync(SlotModel slotModel);
        Task UpdateSlotAsync(int slotId, SlotModel slotModel);
        Task DeleteSlotAsync(int slotId);
    }
}
