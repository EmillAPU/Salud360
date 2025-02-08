using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Salud360.DTO.VerificacionUsuarioDTO;
using Salud360.Services.VerificacionUsuarioServices;

namespace Salud360.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificacionesUsuariosController : ControllerBase
    {
        private readonly IVerificacionUsuarioService _verificacionUsuarioService;

        public VerificacionesUsuariosController(IVerificacionUsuarioService verificacionUsuarioService)
        {
            _verificacionUsuarioService = verificacionUsuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VerificacionUsuarioGetDTO>>> GetVerificacionesUsuarios()
        {
            try
            {
                var verificaciones = await _verificacionUsuarioService.GetAllAsync();
                return Ok(verificaciones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VerificacionUsuarioGetDTO>> GetVerificacionUsuario(int id)
        {
            try
            {
                var verificacion = await _verificacionUsuarioService.GetByIdAsync(id);
                if (verificacion == null)
                {
                    return NotFound("Verificación de usuario no encontrada.");
                }
                return Ok(verificacion);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<VerificacionUsuarioGetDTO>> PostVerificacionUsuario(VerificacionUsuarioInsertDTO verificacionDto)
        {
            try
            {
                var createdVerificacion = await _verificacionUsuarioService.CreateAsync(verificacionDto);
                return CreatedAtAction(nameof(GetVerificacionUsuario), new { id = createdVerificacion.VerificacionId }, createdVerificacion);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVerificacionUsuario(int id, VerificacionUsuarioPutDTO verificacionDto)
        {
            if (id != verificacionDto.VerificacionId)
            {
                return BadRequest("El ID en la URL no coincide con el ID en el cuerpo de la solicitud.");
            }

            try
            {
                var updatedVerificacion = await _verificacionUsuarioService.UpdateAsync(id, verificacionDto);
                return Ok(updatedVerificacion);
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
        public async Task<IActionResult> DeleteVerificacionUsuario(int id)
        {
            try
            {
                var deleted = await _verificacionUsuarioService.DeleteAsync(id);
                if (!deleted)
                {
                    return NotFound("Verificación de usuario no encontrada.");
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
