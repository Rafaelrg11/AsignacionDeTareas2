using AsignacionDeTareas2.DTOs;
using AsignacionDeTareas2.Models;
using AsignacionDeTareas2.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AsignacionDeTareas2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProyectsController : Controller
    {
        public ApplicationDbcontext _dbcontext;

        public ProyectsOperations _operations;
        public ProyectsController(ProyectsOperations notification, ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
            _operations = notification;
        }

        [HttpGet("GetProyects")]
        public async Task<IActionResult> GetProyects()
        {
            await _operations.GetProyects();

            var allProyects = await _dbcontext.Proyects.Select(a => new ProyectsDto
            {
                idProyect = a.idProyect,
                nameProyect = a.nameProyect,
                task = a.Tasks.Select(a => new TasksDto2
                {
                    idProyect = a.idProyect,
                    idTask = a.idTask,
                    idUser = a.idUser,
                    nameTask = a.nameTask,
                    descriptionTask = a.descriptionTask,
                    dateTask = a.dateTask,
                    dateTaskCompletion = a.dateTaskCompletion,
                    state = a.state
                }).ToList(),
                Auxiliar = a.AuxiliarT.Select(a => new AuxiliarTDto
                {
                    idAuxiliar = a.idAuxiliar,
                    idProyect = a.idProyect,
                    idUser = a.idUser
                }).ToList()
            }).ToListAsync();

            return Ok(allProyects);
        }

        [HttpGet("GetProyect/{idProyect}")]
        public async Task<IActionResult> GetProyect(int idProyect)
        {
            await _operations.GetProyect(idProyect);

            var proyect = await _dbcontext.Proyects.Where(a => a.idProyect == idProyect).Select(a => new ProyectsDto
            {
                idProyect = a.idProyect,
                nameProyect = a.nameProyect,
                task = a.Tasks.Select(a => new TasksDto2
                {
                    idProyect = a.idProyect,
                    idTask = a.idTask,
                    nameTask = a.nameTask,
                    descriptionTask = a.descriptionTask,
                    dateTask = a.dateTask,
                    dateTaskCompletion = a.dateTaskCompletion
                }).ToList(),
                Auxiliar = a.AuxiliarT.Select(a => new AuxiliarTDto
                {
                    idAuxiliar = a.idAuxiliar,
                    idProyect = a.idProyect,
                    idUser = a.idUser
                }).ToList()
            }).ToListAsync();

            return Ok(proyect);
        }

        [HttpPost("CreateProyect")]
        public async Task<IActionResult> CreateProyect(ProyectDto2 proyectsDto)
        {
            Proyects proyects = new Proyects()
            {
                nameProyect = proyectsDto.nameProyect,
            };

            var result = await _operations.CreateProyect(proyects);

            return Ok(result);
        }

        [HttpPut("UpdateProyect/{idProyect}")]
        public async Task<bool> UpdateProyect(ProyectDto2 proyects)
        {
            var result = await _operations.UpdateProyect(proyects);

            return result;
        }

        [HttpDelete("DeleteProyect/{idProyect}")]
        public async Task<bool> DeleteProyect(int idProyect)
        {
            var result = await _operations.DeleteProyect(idProyect);

            return result;
        }
    }
}
