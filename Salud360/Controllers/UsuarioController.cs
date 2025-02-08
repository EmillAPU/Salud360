using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Salud360.DTO.UsuarioDTO;
using Salud360.Services.UsuarioServices;

namespace Salud360.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioGetDTO>>> GetUsuarios()
        {
            try
            {
                var usuarios = await _usuarioService.GetAllAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioGetDTO>> GetUsuario(int id)
        {
            try
            {
                var usuario = await _usuarioService.GetByIdAsync(id);
                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado.");
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioGetDTO>> PostUsuario(UsuarioInsertDTO usuarioDto)
        {
            try
            {
                var createdUsuario = await _usuarioService.CreateAsync(usuarioDto);
                return CreatedAtAction(nameof(GetUsuario), new { id = createdUsuario.UsuarioId }, createdUsuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioPutDTO usuarioDto)
        {
            if (id != usuarioDto.UsuarioId)
            {
                return BadRequest("El ID en la URL no coincide con el ID en el cuerpo de la solicitud.");
            }

            try
            {
                var updatedUsuario = await _usuarioService.UpdateAsync(id, usuarioDto);
                return Ok(updatedUsuario);
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
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {
                var deleted = await _usuarioService.DeleteAsync(id);
                if (!deleted)
                {
                    return NotFound("Usuario no encontrado.");
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
