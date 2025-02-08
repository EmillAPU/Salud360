using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Salud360.Data;
using Salud360.DTO.ProgresoUsuarioDTO;
using Salud360.Models;
using Salud360.Services.ProgresoUsuarioServices;

namespace Salud360.Services.ProgresoUsuarioServices
{
    public class ProgresoUsuarioService : IProgresoUsuarioService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProgresoUsuarioService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProgresoUsuarioGetDTO>> GetAllAsync()
        {
            var progresos = await _context.ProgresosUsuarios.ToListAsync();
            return _mapper.Map<List<ProgresoUsuarioGetDTO>>(progresos);
        }

        public async Task<ProgresoUsuarioGetDTO> GetByIdAsync(int id)
        {
            var progreso = await _context.ProgresosUsuarios.FindAsync(id);
            return progreso == null ? null : _mapper.Map<ProgresoUsuarioGetDTO>(progreso);
        }

        public async Task<ProgresoUsuarioGetDTO> CreateAsync(ProgresoUsuarioInsertDTO progresoDto)
        {
            var progreso = _mapper.Map<ProgresoUsuario>(progresoDto);
            _context.ProgresosUsuarios.Add(progreso);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProgresoUsuarioGetDTO>(progreso);
        }

        public async Task<ProgresoUsuarioGetDTO> UpdateAsync(int id, ProgresoUsuarioPutDTO progresoDto)
        {
            var existingProgreso = await _context.ProgresosUsuarios.FindAsync(id);
            if (existingProgreso == null)
            {
                throw new KeyNotFoundException("Progreso de usuario no encontrado.");
            }

            _mapper.Map(progresoDto, existingProgreso);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProgresoUsuarioGetDTO>(existingProgreso);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var progreso = await _context.ProgresosUsuarios.FindAsync(id);
            if (progreso == null)
            {
                return false;
            }

            _context.ProgresosUsuarios.Remove(progreso);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}