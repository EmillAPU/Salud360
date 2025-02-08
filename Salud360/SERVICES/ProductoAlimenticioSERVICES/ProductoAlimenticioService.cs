using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Salud360.Data;
using Salud360.DTO.ProductoAlimenticioDTO;
using Salud360.Models;
using Salud360.Services.ProductoAlimenticioServices;

namespace Salud360.Services.ProductoAlimenticioServices
{
    public class ProductoAlimenticioService : IProductoAlimenticioService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductoAlimenticioService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductoAlimenticioGetDTO>> GetAllAsync()
        {
            var productos = await _context.ProductosAlimenticios.ToListAsync();
            return _mapper.Map<List<ProductoAlimenticioGetDTO>>(productos);
        }

        public async Task<ProductoAlimenticioGetDTO> GetByIdAsync(int id)
        {
            var producto = await _context.ProductosAlimenticios.FindAsync(id);
            return producto == null ? null : _mapper.Map<ProductoAlimenticioGetDTO>(producto);
        }

        public async Task<ProductoAlimenticioGetDTO> CreateAsync(ProductoAlimenticioInsertDTO productoDto)
        {
            var producto = _mapper.Map<ProductoAlimenticio>(productoDto);
            _context.ProductosAlimenticios.Add(producto);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductoAlimenticioGetDTO>(producto);
        }

        public async Task<ProductoAlimenticioGetDTO> UpdateAsync(int id, ProductoAlimenticioPutDTO productoDto)
        {
            var existingProducto = await _context.ProductosAlimenticios.FindAsync(id);
            if (existingProducto == null)
            {
                throw new KeyNotFoundException("Producto alimenticio no encontrado.");
            }

            _mapper.Map(productoDto, existingProducto);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductoAlimenticioGetDTO>(existingProducto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var producto = await _context.ProductosAlimenticios.FindAsync(id);
            if (producto == null)
            {
                return false;
            }

            _context.ProductosAlimenticios.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}