using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashParkMVP.DataModels
{
    [Index("ParkingSpaceId")]
    [Index("ParkingLotId")]
    public class ParkingSpace
    {
        [Key]
        public int ParkingSpaceId { get; set; }
        public int ParkingLotId { get; set; }
        public bool IsAvailable { get; set; }


        [ForeignKey("ParkingLotId")]
        public virtual ParkingLot ParkingLot { get; set; }
    }
}
