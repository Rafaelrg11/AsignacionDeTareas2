using AsignacionDeTareas2.DTOs;
using AsignacionDeTareas2.Models;
using AsignacionDeTareas2.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AsignacionDeTareas2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolController : Controller
    {
        public ApplicationDbcontext _context;

        public RolOperation _operation;
        public RolController(ApplicationDbcontext applicationDbcontext, RolOperation operation)
        {
            _context = applicationDbcontext;
            _operation = operation;
        }

        [HttpGet("GetRols")]
        public async Task<IActionResult> GetRols()
        {
            await _operation.GetRols();

            var allRols = await _context.Rols.Select(a => new RolDto
            {
                IdRol = a.IdRol,
                nombre = a.nombre,
                Operacion = a.Operacion.Select(a => new OperacionesDto2
                {
                    IdRol = a.IdRol,
                    IdOperaciones = a.IdOperaciones,
                    IdOperationRol = a.IdOperationRol
                }).ToList(),
                User = a.Users.Select(a => new UserDto2
                {
                    nameUser = a.nameUser,
                    emailUser = a.emailUser,
                    password = a.password,
                    idUser = a.idUser,
                    IdRol = a.IdRol
                }).ToList()
            }).ToListAsync();

            return Ok(allRols);
        }

        [HttpGet("GetRol/{idRol}")]
        public async Task<IActionResult> GetRol(int idRol)
        {
            await _operation.GetRol(idRol);

            var rols = await _context.Rols.Where(a => a.IdRol == idRol).Select(a => new RolDto
            {
                IdRol = a.IdRol,
                nombre = a.nombre,
                Operacion = a.Operacion.Select(a => new OperacionesDto2
                {
                    IdRol = a.IdRol,
                    IdOperaciones = a.IdOperaciones,
                    IdOperationRol = a.IdOperationRol
                }).ToList(),
                User = a.Users.Select(a => new UserDto2
                {
                    nameUser = a.nameUser,
                    emailUser = a.emailUser,
                    password = a.password,
                    idUser = a.idUser,
                    IdRol = a.IdRol
                }).ToList()
            }).ToListAsync();

            return Ok(rols);
        }

        [HttpPost("CreateRol")]
        public async Task<IActionResult> CreateRol([FromBody] RolDto2 rolDto)
        {
            Rol rol = new Rol()
            {
                nombre = rolDto.nombre,
            };
            var operation = await _operation.CreateRol(rol);

            return Ok(operation);
        }

        [HttpPut("UpdateRol/{idRol}")]
        public async Task<bool> UpdateRol([FromBody] RolDto2 rol)
        {
            var operation = await _operation.UpdateRol(rol);

            return operation;
        }

        [HttpDelete("DeleteRol/{idRol}")]
        public async Task<bool> DeleteRol(int idRol)
        {
            var result = await _operation.DeleteRol(idRol);

            return result;
        }
    }
}
