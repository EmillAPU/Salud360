using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Salud360.DTO.EjercicioDTO;
using Salud360;
using Salud360.Services.AulaServices;

namespace Salud360.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjerciciosController : ControllerBase
    {
        private readonly IEjercicioService _ejercicioService;

        public EjerciciosController(IEjercicioService ejercicioService)
        {
            _ejercicioService = ejercicioService;
        }

        // GET: api/Aulas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EjercicioGetDTO>>> GetEjercicios()
        {
            try
            {
                var ejercicios = await _ejercicioService.GetAllAsync();
                return Ok(ejercicios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // GET: api/Aulas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EjercicioGetDTO>> GetEjercicio(int id)
        {
            try
            {
                var ejercicio = await _ejercicioService.GetByIdAsync(id);

                if (ejercicio == null)
                {
                    return NotFound("Ejercicio no encontrada.");
                }

                return Ok(ejercicio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT: api/Aulas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEjercicio(int id, EjercicioPutDTO ejercicioDTO)
        {
            if (id != ejercicioDTO.EjercicioId)
            {
                return BadRequest("El ID del ejercicio en la URL no coincide con el ID en el cuerpo de la solicitud.");
            }

            try
            {
                var updatedEjercicio = await _ejercicioService.UpdateAsync(id, ejercicioDTO);
                return Ok(updatedEjercicio);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // POST: api/Aulas
        [HttpPost]
        public async Task<ActionResult<EjercicioGetDTO>> PostEjercicio(EjercicioInsertDTO ejercicioDTO)
        {
            try
            {
                var createdEjercicio = await _ejercicioService.CreateAsync(ejercicioDTO);
                return CreatedAtAction(nameof(GetEjercicio), new { id = createdEjercicio.EjercicioId }, createdEjercicio);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // DELETE: api/Aulas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEjercicio(int id)
        {
            try
            {
                var deleted = await _ejercicioService.DeleteAsync(id);
                if (!deleted)
                {
                    return NotFound("Ejercicio no encontrado.");
                }

                return NoContent();
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
    }
}
