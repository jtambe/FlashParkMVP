using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlashParkMVP.DataModels
{
    [Index("ParkingLotId")]
    public class ParkingLot
    {
        [Key]
        public int ParkingLotId { get; set; }
        public string ParkingLotAddress { get; set; }
        public virtual ICollection<ParkingSpace> ParkingSpaces { get; set; }
    }
}
