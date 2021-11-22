namespace FlashParkMVP.DTOs
{
    public class ParkingLotDto
    {
        public int ParkingLotId { get; set; }
        public string ParkingLotAddress { get; set; }

        public int TotalSpaces { get; set; }
        public int AvailableSpaces { get; set; }
    }
}
