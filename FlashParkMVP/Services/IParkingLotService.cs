using FlashParkMVP.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlashParkMVP.Services
{
    public interface IParkingLotService
    {
        public Task<IEnumerable<ParkingLot>> GetParkingLotsAsync();
    }
}
