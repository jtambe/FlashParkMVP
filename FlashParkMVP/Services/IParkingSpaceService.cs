using FlashParkMVP.DataModels;
using System.Threading.Tasks;

namespace FlashParkMVP.Services
{
    public interface IParkingSpaceService
    {
        public Task<ParkingSpace> AddVehicle(int parkingLotId);
        public Task<ParkingSpace> RemoveVehicle(int parkingLotId);
    }
}
