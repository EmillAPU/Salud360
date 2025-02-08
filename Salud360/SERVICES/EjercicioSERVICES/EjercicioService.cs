using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Salud360.DTO.EjercicioDTO;
using Salud360.Models;
using Salud360.Data;

namespace Salud360.Services.AulaServices
{
    public class EjercicioService : IEjercicioService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EjercicioService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EjercicioGetDTO>> GetAllAsync()
        {
            var ejercicio = await _context.Ejercicios.ToListAsync();
            return _mapper.Map<List<EjercicioGetDTO>>(ejercicio);
        }

        public async Task<EjercicioGetDTO> GetByIdAsync(int id)
        {
            var ejercicio = await _context.Ejercicios.FindAsync(id);
            return ejercicio == null ? null : _mapper.Map<EjercicioGetDTO>(ejercicio);
        }

        public async Task<EjercicioGetDTO> CreateAsync(EjercicioInsertDTO ejercicioDto)
        {
            var ejercicio = _mapper.Map<Ejercicio>(ejercicioDto);

            if (await _context.Ejercicios.AnyAsync(a => a.Nombre == ejercicio.Nombre))
            {
                throw new ArgumentException("Ya existe un ejercicio con ese nombre.");
            }

            _context.Ejercicios.Add(ejercicio);
            await _context.SaveChangesAsync();
            return _mapper.Map<EjercicioGetDTO>(ejercicio);
        }

        public async Task<EjercicioGetDTO> UpdateAsync(int id, EjercicioPutDTO ejercicioDto)
        {
            var existingEjercicio = await _context.Ejercicios.FindAsync(id);
            if (existingEjercicio == null)
            {
                throw new KeyNotFoundException();
            }

            if (await _context.Ejercicios.AnyAsync(a => a.Nombre == ejercicioDto.Nombre && a.EjercicioId != id))
            {
                throw new ArgumentException("Ya existe un ejercicio con ese nombre.");
            }

            _mapper.Map(ejercicioDto, existingEjercicio);

            _context.Entry(ejercicioDto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return _mapper.Map<EjercicioGetDTO>(existingEjercicio);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ejercicio = await _context.Ejercicios.FindAsync(id);
            if (ejercicio == null)
            {
                return false;
            }

            _context.Ejercicios.Remove(ejercicio);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
