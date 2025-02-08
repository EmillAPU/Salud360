using System.Collections.Generic;
using System.Threading.Tasks;
using Salud360.DTO.UsuarioDTO;

namespace Salud360.Services.UsuarioServices
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioGetDTO>> GetAllAsync();
        Task<UsuarioGetDTO> GetByIdAsync(int id);
        Task<UsuarioGetDTO> CreateAsync(UsuarioInsertDTO usuarioDto);
        Task<UsuarioGetDTO> UpdateAsync(int id, UsuarioPutDTO usuarioDto);
        Task<bool> DeleteAsync(int id);
    }
}