using AsignacionDeTareas2.DTOs;
using AsignacionDeTareas2.Models;
using Microsoft.EntityFrameworkCore;

namespace AsignacionDeTareas2.Operations
{
    public class Operation_RolOperations
    {
        public ApplicationDbcontext _context;
        public Operation_RolOperations(ApplicationDbcontext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<List<Operations_Rol>> GetOperations_Rols()
        {
            var result = await _context.OperationRols.AsNoTracking().ToListAsync();

            return result;
        }

        public async Task<Operations_Rol> GetOperations_Rol(int idOperation)
        {
            var result = await _context.OperationRols.FindAsync(idOperation);

            return result;
        }

        public async Task<Operations_Rol> CreateOperationRols(Operations_Rol operations)
        {
            var result = await _context.OperationRols.AddAsync(operations);

            await _context.SaveChangesAsync();

            return operations;
        }

        public async Task<bool> UpdateOperationRol(Operations_rolDto2 operations_RolDto)
        {
            Operations_Rol? operations = await _context.OperationRols.FindAsync(operations_RolDto.IdOperationsRol);
            if (operations != null)
            {
                operations.NameOperationRol = operations_RolDto.NameOperationRol;

                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteOperationRol(int idoperation)
        {
            var result = await _context.OperationRols.FindAsync(idoperation);
            if (result == null)
            {
                return false;
            }
            _context.OperationRols.Remove(result);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
