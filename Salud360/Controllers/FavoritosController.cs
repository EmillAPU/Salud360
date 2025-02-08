using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Salud360.DTO.FavoritoDTO;
using Salud360.Services.FavoritoServices;

namespace Salud360.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritosController : ControllerBase
    {
        private readonly IFavoritoService _favoritoService;

        public FavoritosController(IFavoritoService favoritoService)
        {
            _favoritoService = favoritoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoritoGetDTO>>> GetFavoritos()
        {
            try
            {
                var favoritos = await _favoritoService.GetAllAsync();
                return Ok(favoritos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FavoritoGetDTO>> GetFavorito(int id)
        {
            try
            {
                var favorito = await _favoritoService.GetByIdAsync(id);
                if (favorito == null)
                {
                    return NotFound("Favorito no encontrado.");
                }
                return Ok(favorito);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<FavoritoGetDTO>> PostFavorito(FavoritoInsertDTO favoritoDto)
        {
            try
            {
                var createdFavorito = await _favoritoService.CreateAsync(favoritoDto);
                return CreatedAtAction(nameof(GetFavorito), new { id = createdFavorito.FavoritosId }, createdFavorito);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavorito(int id, FavoritoPutDTO favoritoDto)
        {
            if (id != favoritoDto.FavoritosId)
            {
                return BadRequest("El ID en la URL no coincide con el ID en el cuerpo de la solicitud.");
            }

            try
            {
                var updatedFavorito = await _favoritoService.UpdateAsync(id, favoritoDto);
                return Ok(updatedFavorito);
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
        public async Task<IActionResult> DeleteFavorito(int id)
        {
            try
            {
                var deleted = await _favoritoService.DeleteAsync(id);
                if (!deleted)
                {
                    return NotFound("Favorito no encontrado.");
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
