using System.Collections.Generic;
using System.Threading.Tasks;
using Salud360.DTO.PlanNutricionalDTO;

namespace Salud360.Services.PlanNutricionalServices
{
    public interface IPlanNutricionalService
    {
        Task<IEnumerable<PlanNutricionalGetDTO>> GetAllAsync();
        Task<PlanNutricionalGetDTO> GetByIdAsync(int id);
        Task<PlanNutricionalGetDTO> CreateAsync(PlanNutricionalInsertDTO planDto);
        Task<PlanNutricionalGetDTO> UpdateAsync(int id, PlanNutricionalPutDTO planDto);
        Task<bool> DeleteAsync(int id);
    }
}