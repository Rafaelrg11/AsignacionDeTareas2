using AsignacionDeTareas2.DTOs;
using AsignacionDeTareas2.Models;
using Microsoft.EntityFrameworkCore;

namespace AsignacionDeTareas2.Operations
{
    public class RolOperation
    {
        public ApplicationDbcontext _context;

        public RolOperation(ApplicationDbcontext context)
        {
            _context = context;
        }

        public async Task<List<Rol>> GetRols()
        {
            var result = await _context.Rols.AsNoTracking().ToListAsync();

            return result;
        }

        public async Task<Rol> GetRol(int idrol)
        {
            var result = await _context.Rols.FindAsync(idrol);

            return result;
        }

        public async Task<Rol> CreateRol(Rol rol)
        {
            var result = await _context.Rols.AddAsync(rol);

            _context.SaveChanges();

            return rol;
        }

        public async Task<bool> UpdateRol(RolDto2 rolDto)
        {
            Rol? rol = await _context.Rols.FindAsync(rolDto.IdRol);
            if (rol != null)
            {
                rol.nombre = rolDto.nombre;

                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteRol(int idRol)
        {
            var result = await _context.Rols.FindAsync(idRol);
            if (result == null)
            {
                return false;
            }
            _context.Rols.Remove(result);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
