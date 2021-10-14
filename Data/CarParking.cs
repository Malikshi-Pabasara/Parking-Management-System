using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManagementSystemApi.Data
{
    public class CarParking
    {
        [Key]
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Date { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        [ForeignKey("Slot")]
        public int SlotId { get; set; }
        public Slot Slot { get; set; }

    }
}
