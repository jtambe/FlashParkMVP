using FlashParkMVP.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlashParkMVP.Services
{
    public class ParkingLotService: IParkingLotService
    {
        private DBContext _dbContext;
        public ParkingLotService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<ParkingLot>> GetParkingLotsAsync()
        {
            var parkingLots = await _dbContext.ParkingLots.Include(lot => lot.ParkingSpaces).ToListAsync();

            foreach (var parkingLot in parkingLots)
            {
                foreach (var parkingSpace in parkingLot.ParkingSpaces)
                {
                    parkingSpace.ParkingLot = null;
                }
            }

            return parkingLots; 
        }
    }
}
