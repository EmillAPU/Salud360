using System.Collections.Generic;
using System.Threading.Tasks;
using Salud360.DTO.ProgresoUsuarioDTO;

namespace Salud360.Services.ProgresoUsuarioServices
{
    public interface IProgresoUsuarioService
    {
        Task<IEnumerable<ProgresoUsuarioGetDTO>> GetAllAsync();
        Task<ProgresoUsuarioGetDTO> GetByIdAsync(int id);
        Task<ProgresoUsuarioGetDTO> CreateAsync(ProgresoUsuarioInsertDTO progresoDto);
        Task<ProgresoUsuarioGetDTO> UpdateAsync(int id, ProgresoUsuarioPutDTO progresoDto);
        Task<bool> DeleteAsync(int id);
    }
}