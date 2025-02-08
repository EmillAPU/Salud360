using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Salud360.Data;
using Salud360.DTO.FavoritoDTO;
using Salud360.Models;

namespace Salud360.Services.FavoritoServices
{
    public class FavoritoService : IFavoritoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FavoritoService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FavoritoGetDTO>> GetAllAsync()
        {
            var favoritos = await _context.Favoritos.ToListAsync();
            return _mapper.Map<List<FavoritoGetDTO>>(favoritos);
        }

        public async Task<FavoritoGetDTO> GetByIdAsync(int id)
        {
            var favorito = await _context.Favoritos.FindAsync(id);
            return favorito == null ? null : _mapper.Map<FavoritoGetDTO>(favorito);
        }

        public async Task<FavoritoGetDTO> CreateAsync(FavoritoInsertDTO favoritoDto)
        {
            var favorito = _mapper.Map<Favorito>(favoritoDto);
            _context.Favoritos.Add(favorito);
            await _context.SaveChangesAsync();
            return _mapper.Map<FavoritoGetDTO>(favorito);
        }

        public async Task<FavoritoGetDTO> UpdateAsync(int id, FavoritoPutDTO favoritoDto)
        {
            var existingFavorito = await _context.Favoritos.FindAsync(id);
            if (existingFavorito == null)
            {
                throw new KeyNotFoundException("Favorito no encontrado.");
            }

            _mapper.Map(favoritoDto, existingFavorito);
            await _context.SaveChangesAsync();
            return _mapper.Map<FavoritoGetDTO>(existingFavorito);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var favorito = await _context.Favoritos.FindAsync(id);
            if (favorito == null)
            {
                return false;
            }

            _context.Favoritos.Remove(favorito);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}