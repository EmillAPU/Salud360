using System.Collections.Generic;
using System.Threading.Tasks;
using Salud360.DTO.ProductoAlimenticioDTO;

namespace Salud360.Services.ProductoAlimenticioServices
{
    public interface IProductoAlimenticioService
    {
        Task<IEnumerable<ProductoAlimenticioGetDTO>> GetAllAsync();
        Task<ProductoAlimenticioGetDTO> GetByIdAsync(int id);
        Task<ProductoAlimenticioGetDTO> CreateAsync(ProductoAlimenticioInsertDTO productoDto);
        Task<ProductoAlimenticioGetDTO> UpdateAsync(int id, ProductoAlimenticioPutDTO productoDto);
        Task<bool> DeleteAsync(int id);
    }
}