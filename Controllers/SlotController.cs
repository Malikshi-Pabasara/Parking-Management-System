using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingManagementSystemApi.Models;
using ParkingManagementSystemApi.Repository;

namespace ParkingManagementSystemApi.Controllers
{
    [Route("api/slots")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        private readonly ISlotRepository _slotRepository;
        public SlotController(ISlotRepository slotRepository)
        {
            _slotRepository = slotRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllSlots()
        {
            var slots = await _slotRepository.GetAllSlotsAsync();
            return Ok(slots);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSlotById([FromRoute] int id)
        {
            var slot = await _slotRepository.GetSlotByIdAsync(id);
            if (slot == null)
            {
                return NotFound();
            }
            return Ok(slot);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddSlot([FromBody] SlotModel slotModel)
        {
            var id = await _slotRepository.AddSlotAsync(slotModel);
            return CreatedAtAction(nameof(GetSlotById), new { id = id, controller = "Slot" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlot([FromBody] SlotModel slotModel, [FromRoute] int id)
        {
            await _slotRepository.UpdateSlotAsync(id, slotModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlot([FromRoute] int id)
        {
            await _slotRepository.DeleteSlotAsync(id);
            return Ok();
        }

    }
}

