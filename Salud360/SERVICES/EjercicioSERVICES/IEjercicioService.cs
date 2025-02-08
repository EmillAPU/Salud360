using System.Collections.Generic;
using System.Threading.Tasks;
using Salud360.DTO.EjercicioDTO;

namespace Salud360.Services.AulaServices
{
    public interface IEjercicioService
    {
        Task<IEnumerable<EjercicioGetDTO>> GetAllAsync();
        Task<EjercicioGetDTO> GetByIdAsync(int id);
        Task<EjercicioGetDTO> CreateAsync(EjercicioInsertDTO aulaDto);
        Task<EjercicioGetDTO> UpdateAsync(int id, EjercicioPutDTO aulaDto);
        Task<bool> DeleteAsync(int id);
    }
}
