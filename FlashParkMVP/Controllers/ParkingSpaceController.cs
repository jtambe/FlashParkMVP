using FlashParkMVP.DataModels;
using FlashParkMVP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FlashParkMVP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingSpaceController : ControllerBase
    {

        private readonly ILogger<ParkingSpaceController> _logger;
        private readonly IParkingSpaceService _parkingSpaceService;

        public ParkingSpaceController(ILogger<ParkingSpaceController> logger, IParkingSpaceService parkingSpaceService)
        {
            _logger = logger;
            _parkingSpaceService = parkingSpaceService;
        }
        

        [HttpPost("AddVehicle/{parkingLotId}")]
        [ActionName("AddVehicle")]
        public async Task<ParkingSpace> AddVehicle(int parkingLotId)
        {
            ParkingSpace result = new ParkingSpace();
            try
            {
                result = await _parkingSpaceService.AddVehicle(parkingLotId);
                return result;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return result;
            }
           
        }

        [HttpPost("RemoveVehicle/{parkingLotId}")]
        [ActionName("RemoveVehicle")]
        public async Task<ParkingSpace> RemoveVehicle(int parkingLotId)
        {
            ParkingSpace result = new ParkingSpace();
            try
            {
                result = await _parkingSpaceService.RemoveVehicle(parkingLotId);
                return result;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return result;
            }
            
        }
    }
}
