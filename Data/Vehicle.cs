using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingManagementSystemApi.Data
{ 

    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public string VehicleNO { get; set; }
        public bool IsDefault { get; set; }
    }
}
