namespace ParkingManagementSystemApi.Models
{
    public class SlotModel
    {
        public int SlotId { get; set; }
        public int ParkId { get; set; }
        public string CurrentVehicleNo { get; set; }
        public string Status { get; set; }
        public string SlotNo { get; set; }
        public bool IsActive { get; set; }
    }
}
