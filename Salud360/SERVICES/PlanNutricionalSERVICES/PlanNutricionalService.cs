using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Salud360.Data;
using Salud360.DTO.PlanNutricionalDTO;
using Salud360.Models;

namespace Salud360.Services.PlanNutricionalServices
{
    public class PlanNutricionalService : IPlanNutricionalService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PlanNutricionalService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlanNutricionalGetDTO>> GetAllAsync()
        {
            var planes = await _context.PlanesNutricionales.ToListAsync();
            return _mapper.Map<List<PlanNutricionalGetDTO>>(planes);
        }

        public async Task<PlanNutricionalGetDTO> GetByIdAsync(int id)
        {
            var plan = await _context.PlanesNutricionales.FindAsync(id);
            return plan == null ? null : _mapper.Map<PlanNutricionalGetDTO>(plan);
        }

        public async Task<PlanNutricionalGetDTO> CreateAsync(PlanNutricionalInsertDTO planDto)
        {
            var plan = _mapper.Map<PlanNutricional>(planDto);
            _context.PlanesNutricionales.Add(plan);
            await _context.SaveChangesAsync();
            return _mapper.Map<PlanNutricionalGetDTO>(plan);
        }

        public async Task<PlanNutricionalGetDTO> UpdateAsync(int id, PlanNutricionalPutDTO planDto)
        {
            var existingPlan = await _context.PlanesNutricionales.FindAsync(id);
            if (existingPlan == null)
            {
                throw new KeyNotFoundException("Plan nutricional no encontrado.");
            }

            _mapper.Map(planDto, existingPlan);
            await _context.SaveChangesAsync();
            return _mapper.Map<PlanNutricionalGetDTO>(existingPlan);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var plan = await _context.PlanesNutricionales.FindAsync(id);
            if (plan == null)
            {
                return false;
            }

            _context.PlanesNutricionales.Remove(plan);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}