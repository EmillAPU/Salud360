using System.Collections.Generic;
using System.Threading.Tasks;
using Salud360.DTO.VerificacionUsuarioDTO;

namespace Salud360.Services.VerificacionUsuarioServices
{
    public interface IVerificacionUsuarioService
    {
        Task<IEnumerable<VerificacionUsuarioGetDTO>> GetAllAsync();
        Task<VerificacionUsuarioGetDTO> GetByIdAsync(int id);
        Task<VerificacionUsuarioGetDTO> CreateAsync(VerificacionUsuarioInsertDTO verificacionDto);
        Task<VerificacionUsuarioGetDTO> UpdateAsync(int id, VerificacionUsuarioPutDTO verificacionDto);
        Task<bool> DeleteAsync(int id);
    }
}