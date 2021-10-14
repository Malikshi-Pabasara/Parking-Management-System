
namespace ParkingManagementSystemApi.Models
{
    public class VehicleModel
    {
        public int VehicleId { get; set; }
        public int UserId { get; set; }
        public string VehicleNO { get; set; }
        public bool IsDefault { get; set; }
    }
}
