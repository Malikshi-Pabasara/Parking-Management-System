namespace ParkingManagementSystemApi.Models
{
    public class CarParkModel
    {
        public int ParkId { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsActive { get; set; }
    }
}
