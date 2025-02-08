using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Salud360.Data;
using Salud360.DTO.VerificacionUsuarioDTO;
using Salud360.Models;
using Salud360.Services;

namespace Salud360.Services.VerificacionUsuarioServices
{
    public class VerificacionUsuarioService : IVerificacionUsuarioService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VerificacionUsuarioService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VerificacionUsuarioGetDTO>> GetAllAsync()
        {
            var verificaciones = await _context.VerificacionesUsuarios.ToListAsync();
            return _mapper.Map<List<VerificacionUsuarioGetDTO>>(verificaciones);
        }

        public async Task<VerificacionUsuarioGetDTO> GetByIdAsync(int id)
        {
            var verificacion = await _context.VerificacionesUsuarios.FindAsync(id);
            return verificacion == null ? null : _mapper.Map<VerificacionUsuarioGetDTO>(verificacion);
        }

        public async Task<VerificacionUsuarioGetDTO> CreateAsync(VerificacionUsuarioInsertDTO verificacionDto)
        {
            var verificacion = _mapper.Map<VerificacionUsuario>(verificacionDto);
            _context.VerificacionesUsuarios.Add(verificacion);
            await _context.SaveChangesAsync();
            return _mapper.Map<VerificacionUsuarioGetDTO>(verificacion);
        }

        public async Task<VerificacionUsuarioGetDTO> UpdateAsync(int id, VerificacionUsuarioPutDTO verificacionDto)
        {
            var existingVerificacion = await _context.VerificacionesUsuarios.FindAsync(id);
            if (existingVerificacion == null)
            {
                throw new KeyNotFoundException("Verificación de usuario no encontrada.");
            }

            _mapper.Map(verificacionDto, existingVerificacion);
            await _context.SaveChangesAsync();
            return _mapper.Map<VerificacionUsuarioGetDTO>(existingVerificacion);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var verificacion = await _context.VerificacionesUsuarios.FindAsync(id);
            if (verificacion == null)
            {
                return false;
            }

            _context.VerificacionesUsuarios.Remove(verificacion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}