using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingManagementSystemApi.Models;
using ParkingManagementSystemApi.Repository;

namespace ParkingManagementSystemApi.Controllers
{
    [Route("api/parks")]
    [ApiController]
    public class CarParkController : ControllerBase
    {
        private readonly ICarParkRepository _carParkRepository;
        public CarParkController(ICarParkRepository carParkRepository)
        {
            _carParkRepository = carParkRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCarParks()
        {
            var parks = await _carParkRepository.GetAllCarParksAsync();
            return Ok(parks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarParkById([FromRoute] int id)
        {
            var park = await _carParkRepository.GetCarParkByIdAsync(id);
            if (park == null)
            {
                return NotFound();
            }
            return Ok(park);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddCarPark([FromBody] CarParkModel carparkodel)
        {
            var id = await _carParkRepository.AddCarParkAsync(carparkodel);
            return CreatedAtAction(nameof(GetCarParkById), new { id = id, controller = "CarPark" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarPark([FromBody] CarParkModel carparkodel, [FromRoute] int id)
        {
            await _carParkRepository.UpdateCarParkAsync(id, carparkodel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarPark([FromRoute] int id)
        {
            await _carParkRepository.DeleteCarParkAsync(id);
            return Ok();
        }

    }
}


