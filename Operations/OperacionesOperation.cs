using AsignacionDeTareas2.DTOs;
using AsignacionDeTareas2.Models;
using Microsoft.EntityFrameworkCore;

namespace AsignacionDeTareas2.Operations
{
    public class OperacionesOperation
    {
        public ApplicationDbcontext _context;
        public OperacionesOperation(ApplicationDbcontext dbcontext)
        {
            _context = dbcontext;
        }
        public async Task<List<Operaciones>> GetOperaciones()
        {
            var result = await _context.Operations.AsNoTracking().ToListAsync();

            return result;
        }

        public async Task<Operaciones> GetOperation(int idOperation)
        {
            var result = await _context.Operations.FindAsync(idOperation);

            return result;
        }

        public async Task<Operaciones> CreateOperations(Operaciones operations)
        {
            var result = await _context.Operations.AddAsync(operations);

            await _context.SaveChangesAsync();

            return operations;
        }

        public async Task<bool> UpdateOperation(OperacionesDto2 operations)
        {
            Operaciones? ope = await _context.Operations.FindAsync(operations.IdOperaciones);
            if (ope != null)
            {
                ope.IdOperationRol = operations.IdOperationRol;
                ope.IdRol = operations.IdRol;

                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteOperaion(int idOperation)
        {
            var result = await _context.Operations.FindAsync(idOperation);
            if (result == null)
            {
                return false;
            }
            _context.Operations.Remove(result);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
