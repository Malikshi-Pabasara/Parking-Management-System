using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingManagementSystemApi.Data 
{ 
    public class Slot
    {
        [Key]
        public int SlotId { get; set; }

        [ForeignKey("Park")]
        public int ParkId { get; set; }
        public Park Park { get; set; }
        public string CurrentVehicleNo { get; set; }
        public string Status { get; set; }
        public string SlotNo { get; set; }
        public bool IsActive { get; set; }
    }
}
