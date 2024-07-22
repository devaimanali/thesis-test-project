using Microsoft.AspNetCore.Mvc;
using thesis_exercise.Models;
using thesis_exercise.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace thesis_exercise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComputerController : ControllerBase
    {
        private readonly IComputerService _computerService;

        public ComputerController(IComputerService computerService)
        {
            this._computerService = computerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Computer>>> Get()
        {
            try
            {
                IEnumerable<Computer> computers = await _computerService.GetAllComputersAsync();
                return Ok(computers);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Computer computer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _computerService.SaveComputerAsync(computer);
                return CreatedAtAction(nameof(Get), new { id = computer.ComputerID }, computer);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Computer computer)
        {
            if (id != computer.ComputerID)
            {
                return BadRequest("Computer ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _computerService.UpdateComputerAsync(computer);
                return CreatedAtAction(nameof(Get), new { id = computer.ComputerID }, computer);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }
    }
}
