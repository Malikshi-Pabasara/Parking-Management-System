using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParkingManagementSystemApi.Data
{
    public class Park
    {
        [Key]
        public int ParkId { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsActive { get; set; }

       // public ICollection<Slot> Slots { get; set; }
    }
}
