using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Salud360.DTO.PlanNutricionalDTO;
using Salud360.Services.PlanNutricionalServices;

namespace Salud360.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanesNutricionalesController : ControllerBase
    {
        private readonly IPlanNutricionalService _planNutricionalService;

        public PlanesNutricionalesController(IPlanNutricionalService planNutricionalService)
        {
            _planNutricionalService = planNutricionalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanNutricionalGetDTO>>> GetPlanesNutricionales()
        {
            try
            {
                var planes = await _planNutricionalService.GetAllAsync();
                return Ok(planes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlanNutricionalGetDTO>> GetPlanNutricional(int id)
        {
            try
            {
                var plan = await _planNutricionalService.GetByIdAsync(id);
                if (plan == null)
                {
                    return NotFound("Plan nutricional no encontrado.");
                }
                return Ok(plan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<PlanNutricionalGetDTO>> PostPlanNutricional(PlanNutricionalInsertDTO planDto)
        {
            try
            {
                var createdPlan = await _planNutricionalService.CreateAsync(planDto);
                return CreatedAtAction(nameof(GetPlanNutricional), new { id = createdPlan.PlanNutricionalId }, createdPlan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanNutricional(int id, PlanNutricionalPutDTO planDto)
        {
            if (id != planDto.PlanNutricionalId)
            {
                return BadRequest("El ID en la URL no coincide con el ID en el cuerpo de la solicitud.");
            }

            try
            {
                var updatedPlan = await _planNutricionalService.UpdateAsync(id, planDto);
                return Ok(updatedPlan);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanNutricional(int id)
        {
            try
            {
                var deleted = await _planNutricionalService.DeleteAsync(id);
                if (!deleted)
                {
                    return NotFound("Plan nutricional no encontrado.");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
