using System.Collections.Generic;
using System.Threading.Tasks;
using Salud360.DTO.FavoritoDTO;

namespace Salud360.Services.FavoritoServices
{
    public interface IFavoritoService
    {
        Task<IEnumerable<FavoritoGetDTO>> GetAllAsync();
        Task<FavoritoGetDTO> GetByIdAsync(int id);
        Task<FavoritoGetDTO> CreateAsync(FavoritoInsertDTO favoritoDto);
        Task<FavoritoGetDTO> UpdateAsync(int id, FavoritoPutDTO favoritoDto);
        Task<bool> DeleteAsync(int id);
    }
}