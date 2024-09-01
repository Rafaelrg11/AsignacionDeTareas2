using AsignacionDeTareas2.DTOs;
using AsignacionDeTareas2.Models;
using AsignacionDeTareas2.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AsignacionDeTareas2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuxiliarTController : Controller
    {
        public ApplicationDbcontext _context;
        public AuxiliarTOperations _operations;
        public AuxiliarTController(ApplicationDbcontext dbcontext, AuxiliarTOperations operations)
        {
            _operations = operations;
            _context = dbcontext;
        }

        [HttpGet("GetAuxiliars")]
        public async Task<IActionResult> GetAuxiliars()
        {
            await _operations.GetAuxiliars();

            var allAuxiliar = await _context.AuxiliarTs.Select(a => new AuxiliarTDto2
            {
                idAuxiliar = a.idAuxiliar,
                idProyect = a.idProyect,
                idUser = a.idUser,
                UserDto = new UsersCustomDto
                {
                    idUser = a.idUser,
                    nameUser = a.User.nameUser,
                    emailUser = a.User.emailUser,
                    password = a.User.password,
                    IdRol = a.User.IdRol
                },
                proyectDto = new ProyectDto2
                {
                    idProyect = a.idProyect,
                    nameProyect = a.Proyect.nameProyect
                }
            }).ToListAsync();

            return Ok(allAuxiliar);
        }

        [HttpGet("GetAuxiliar/{idAuxiliar}")]
        public async Task<IActionResult> GetAuxiliar(int idAuxiliar)
        {
            await _operations.GetAuxiliar(idAuxiliar);

            var auxiliar = await _context.AuxiliarTs.Where(a => a.idAuxiliar == idAuxiliar).Select(a => new AuxiliarTDto2
            {
                idAuxiliar = a.idAuxiliar,
                idProyect = a.idProyect,
                idUser = a.idUser,
                UserDto = new UsersCustomDto
                {
                    idUser = a.idUser,
                    nameUser = a.User.nameUser,
                    emailUser = a.User.emailUser,
                    password = a.User.password,
                    IdRol = a.User.IdRol
                },
                proyectDto = new ProyectDto2
                {
                    idProyect = a.idProyect,
                    nameProyect = a.Proyect.nameProyect
                }
            }).ToListAsync();

            return Ok(auxiliar);
        }

        [HttpPost("CreateAuxiliar")]
        public async Task<IActionResult> CreateAuxiliar(AuxiliarTDto auxiliarTDto)
        {
            AuxiliarT auxiliarT = new AuxiliarT()
            {
                idProyect = auxiliarTDto.idProyect,
                idUser = auxiliarTDto.idUser,
            };
            var operation = await _operations.CreateAuxiliarT(auxiliarT);

            return Ok(operation);
        }
        [HttpPut("UpdateAuxiliar/{idAuxiliar}")]
        public async Task<bool> UpdateAuxiliar(AuxiliarTDto auxiliarTDto)
        {
            var result = await _operations.UpdateAuxiliar(auxiliarTDto);

            return result;
        }

        [HttpDelete("DeleteTask/{idAuxiliar}")]
        public async Task<IActionResult> DeleteAuxiliar(int idAuxiliar)
        {
            var result = await _operations.DeleteAuxiliar(idAuxiliar);

            return Ok("Registro eliminado correctamente");
        }
    }
}
