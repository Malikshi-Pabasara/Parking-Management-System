using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingManagementSystemApi.Models;
using ParkingManagementSystemApi.Repository;

namespace ParkingManagementSystemApi.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllVehicles()
        {
            var vehicles = await _vehicleRepository.GetAllVehiclesAsync();
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById([FromRoute] int id)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddVehicle([FromBody] VehicleModel vehicleModel)
        {
            var id = await _vehicleRepository.AddVehicleAsync(vehicleModel);
            return CreatedAtAction(nameof(GetVehicleById), new { id = id, controller = "Vehicle" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle([FromBody] VehicleModel vehicleModel, [FromRoute] int id)
        {
            await _vehicleRepository.UpdateVehicleAsync(id, vehicleModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle([FromRoute] int id)
        {
            await _vehicleRepository.DeleteVehicleAsync(id);
            return Ok();
        }

    }
}
