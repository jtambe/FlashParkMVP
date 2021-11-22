using FlashParkMVP.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FlashParkMVP.Services
{
    public class ParkingSpaceService: IParkingSpaceService
    {
        private DBContext _dbContext;
        public ParkingSpaceService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ParkingSpace> AddVehicle(int parkingLotId)
        {
            try
            {
                // this can be based on some other business logic to identify closest parking lot/ smallest parking lot of the type of vehicle etc
                var space = await _dbContext.ParkingSpaces.FirstOrDefaultAsync(x => x.ParkingLotId == parkingLotId && x.IsAvailable);
                if (space == null)
                {
                    return new ParkingSpace { ParkingLotId = parkingLotId, ParkingSpaceId = 0 };
                }
                space.IsAvailable = false;
                _dbContext.SaveChanges();
                return space;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ParkingSpace> RemoveVehicle(int parkingLotId)
        {
            try
            {
                // this can be based on some other business logic to identify closest parking lot/ smallest parking lot of the type of vehicle etc
                var space = await _dbContext.ParkingSpaces.FirstOrDefaultAsync(x => x.ParkingLotId == parkingLotId && !x.IsAvailable);
                if (space == null)
                {
                    return new ParkingSpace { ParkingLotId = parkingLotId, ParkingSpaceId = 0 };
                }
                space.IsAvailable = true;
                _dbContext.SaveChanges();
                return space;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
