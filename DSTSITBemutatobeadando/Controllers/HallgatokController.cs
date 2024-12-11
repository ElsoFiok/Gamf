using DSTSITBemutatobeadando.Services;
using DSTSITBemutatobeadando.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSTSITBemutatobeadando.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HallgatokController : ControllerBase
    {
        private readonly HallgatokService _hallgatokService;
        public HallgatokController(HallgatokService hallgatokService) =>
        _hallgatokService = hallgatokService;
        [HttpGet]
        public async Task<List<Hallgato>> Get() =>
            await _hallgatokService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Hallgato>> Get(string id)
        {
            var hallgato = await _hallgatokService.GetAsync(id);

            if (hallgato is null)
            {
                return NotFound();
            }

            return hallgato;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Hallgato newHallgato)
        {
            if (newHallgato == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                await _hallgatokService.CreateAsync(newHallgato);
                return CreatedAtAction(nameof(Get), new { id = newHallgato.Id }, newHallgato);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while creating Hallgato: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Hallgato updatedHallgato)
        {
            var Hallgato = await _hallgatokService.GetAsync(id);

            if (Hallgato is null)
            {
                return NotFound();
            }

            updatedHallgato.Id = Hallgato.Id;

            await _hallgatokService.UpdateAsync(id, updatedHallgato);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var Hallgato = await _hallgatokService.GetAsync(id);

            if (Hallgato is null)
            {
                return NotFound();
            }

            await _hallgatokService.RemoveAsync(id);

            return NoContent();
        }
    }
}
