using FlashParkMVP.DTOs;
using FlashParkMVP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashParkMVP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingLotController : ControllerBase
    {
        private readonly ILogger<ParkingLotController> _logger;
        private readonly IParkingLotService _parkingLotService;

        public ParkingLotController(ILogger<ParkingLotController> logger, IParkingLotService parkingLotService)
        {
            _logger = logger;
            _parkingLotService = parkingLotService;
        }

        [HttpGet("GetParkingLots/")]
        [ActionName("GetParkingLots")]
        public async Task<IEnumerable<ParkingLotDto>> GetParkingLots()
        {
            List<ParkingLotDto> result = new List<ParkingLotDto>();
            try
            {
                // best way to go about this would be use some type of AutoMapper to generate DTO
                var parkingLots = await _parkingLotService.GetParkingLotsAsync();
                foreach (var parkingLot in parkingLots)
                {
                    result.Add(new ParkingLotDto()
                    {
                        ParkingLotId = parkingLot.ParkingLotId,
                        ParkingLotAddress = parkingLot.ParkingLotAddress,
                        TotalSpaces = parkingLot.ParkingSpaces.Count(),
                        AvailableSpaces = parkingLot.ParkingSpaces.Where(x => x.IsAvailable).Count()
                    });
                }
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
