

namespace ParkingManagementSystemApi.Models
{
    public class ParkingModel
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Date { get; set; }
        public int VehicleId { get; set; }
        public int SlotId { get; set; }
    }
}
