using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Salud360.DTO.ProgresoUsuarioDTO;
using Salud360.Services.ProgresoUsuarioServices;

namespace Salud360.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgresosUsuariosController : ControllerBase
    {
        private readonly IProgresoUsuarioService _progresoUsuarioService;

        public ProgresosUsuariosController(IProgresoUsuarioService progresoUsuarioService)
        {
            _progresoUsuarioService = progresoUsuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgresoUsuarioGetDTO>>> GetProgresosUsuarios()
        {
            try
            {
                var progresos = await _progresoUsuarioService.GetAllAsync();
                return Ok(progresos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProgresoUsuarioGetDTO>> GetProgresoUsuario(int id)
        {
            try
            {
                var progreso = await _progresoUsuarioService.GetByIdAsync(id);
                if (progreso == null)
                {
                    return NotFound("Progreso de usuario no encontrado.");
                }
                return Ok(progreso);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProgresoUsuarioGetDTO>> PostProgresoUsuario(ProgresoUsuarioInsertDTO progresoDto)
        {
            try
            {
                var createdProgreso = await _progresoUsuarioService.CreateAsync(progresoDto);
                return CreatedAtAction(nameof(GetProgresoUsuario), new { id = createdProgreso.ProgresoUsuarioId }, createdProgreso);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgresoUsuario(int id, ProgresoUsuarioPutDTO progresoDto)
        {
            if (id != progresoDto.ProgresoUsuarioId)
            {
                return BadRequest("El ID en la URL no coincide con el ID en el cuerpo de la solicitud.");
            }

            try
            {
                var updatedProgreso = await _progresoUsuarioService.UpdateAsync(id, progresoDto);
                return Ok(updatedProgreso);
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
        public async Task<IActionResult> DeleteProgresoUsuario(int id)
        {
            try
            {
                var deleted = await _progresoUsuarioService.DeleteAsync(id);
                if (!deleted)
                {
                    return NotFound("Progreso de usuario no encontrado.");
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
