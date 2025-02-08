using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Salud360.DTO.ProductoAlimenticioDTO;
using Salud360.Services.ProductoAlimenticioServices;

namespace Salud360.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosAlimenticiosController : ControllerBase
    {
        private readonly IProductoAlimenticioService _productoAlimenticioService;

        public ProductosAlimenticiosController(IProductoAlimenticioService productoAlimenticioService)
        {
            _productoAlimenticioService = productoAlimenticioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoAlimenticioGetDTO>>> GetProductosAlimenticios()
        {
            try
            {
                var productos = await _productoAlimenticioService.GetAllAsync();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoAlimenticioGetDTO>> GetProductoAlimenticio(int id)
        {
            try
            {
                var producto = await _productoAlimenticioService.GetByIdAsync(id);
                if (producto == null)
                {
                    return NotFound("Producto alimenticio no encontrado.");
                }
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductoAlimenticioGetDTO>> PostProductoAlimenticio(ProductoAlimenticioInsertDTO productoDto)
        {
            try
            {
                var createdProducto = await _productoAlimenticioService.CreateAsync(productoDto);
                return CreatedAtAction(nameof(GetProductoAlimenticio), new { id = createdProducto.ProductoAlimenticioId }, createdProducto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductoAlimenticio(int id, ProductoAlimenticioPutDTO productoDto)
        {
            if (id != productoDto.ProductoAlimenticioId)
            {
                return BadRequest("El ID en la URL no coincide con el ID en el cuerpo de la solicitud.");
            }

            try
            {
                var updatedProducto = await _productoAlimenticioService.UpdateAsync(id, productoDto);
                return Ok(updatedProducto);
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
        public async Task<IActionResult> DeleteProductoAlimenticio(int id)
        {
            try
            {
                var deleted = await _productoAlimenticioService.DeleteAsync(id);
                if (!deleted)
                {
                    return NotFound("Producto alimenticio no encontrado.");
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