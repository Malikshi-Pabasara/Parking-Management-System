using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingManagementSystemApi.Models;
using ParkingManagementSystemApi.Repository;

namespace ParkingManagementSystemApi.Controllers
{
    [Route("api/parking")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingRepository _parkingRepository;
        public ParkingController(IParkingRepository parkingRepository)
        {
            _parkingRepository = parkingRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllParking()
        {
            var parking = await _parkingRepository.GetAllParkingAsync();
            return Ok(parking);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParkingById([FromRoute] int id)
        {
            var parking = await _parkingRepository.GetParkingByIdAsync(id);
            if (parking == null)
            {
                return NotFound();
            }
            return Ok(parking);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddParking([FromBody] ParkingModel parkingModel)
        {
            var id = await _parkingRepository.AddParkingAsync(parkingModel);
            return CreatedAtAction(nameof(GetParkingById), new { id = id, controller = "Parking" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParking([FromBody] ParkingModel parkingModel, [FromRoute] int id)
        {
            await _parkingRepository.UpdateParkingAsync(id, parkingModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParking([FromRoute] int id)
        {
            await _parkingRepository.DeleteParkingAsync(id);
            return Ok();
        }

    }
}

