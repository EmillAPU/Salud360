using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Salud360.Data;
using Salud360.DTO.UsuarioDTO;
using Salud360.Models;
using Salud360.Services;

namespace Salud360.Services.UsuarioServices
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UsuarioService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioGetDTO>> GetAllAsync()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return _mapper.Map<List<UsuarioGetDTO>>(usuarios);
        }

        public async Task<UsuarioGetDTO> GetByIdAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            return usuario == null ? null : _mapper.Map<UsuarioGetDTO>(usuario);
        }

        public async Task<UsuarioGetDTO> CreateAsync(UsuarioInsertDTO usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return _mapper.Map<UsuarioGetDTO>(usuario);
        }

        public async Task<UsuarioGetDTO> UpdateAsync(int id, UsuarioPutDTO usuarioDto)
        {
            var existingUsuario = await _context.Usuarios.FindAsync(id);
            if (existingUsuario == null)
            {
                throw new KeyNotFoundException("Usuario no encontrado.");
            }

            _mapper.Map(usuarioDto, existingUsuario);
            await _context.SaveChangesAsync();
            return _mapper.Map<UsuarioGetDTO>(existingUsuario);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}