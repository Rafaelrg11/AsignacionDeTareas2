using AsignacionDeTareas2.DTOs;
using AsignacionDeTareas2.Models;
using AsignacionDeTareas2.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AsignacionDeTareas2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : Controller
    {
        public ApplicationDbcontext _dbcontext;

        public TasksOperations _operations;
        public TasksController(TasksOperations notification, ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
            _operations = notification;
        }

        [HttpGet("GetTasks")]
        public async Task<IActionResult> GetTasks()
        {
            await _operations.GetTasks();

            var allTasks = await _dbcontext.Tasks.Select(a => new TasksDto
            {
                idProyect = a.idProyect,
                idTask = a.idTask,
                idUser = a.idUser,
                nameTask = a.nameTask,
                descriptionTask = a.descriptionTask,
                dateTask = a.dateTask,
                dateTaskCompletion = a.dateTaskCompletion,
                state = a.state,
                User = new UsersCustomDto
                {
                    idUser = a.User.idUser,
                    IdRol = a.User.IdRol,
                    nameUser = a.User.nameUser,
                    emailUser = a.User.emailUser,
                    password = a.User.password
                },
                proyects = new ProyectDto2
                {
                    idProyect = a.idProyect,
                    nameProyect = a.Proyects.nameProyect
                },
                comments = a.Comment.Select(a => new CommentsDto
                {
                    idComment = a.idComment,
                    idTask = a.idTask,
                    descriptionCommet = a.descriptionCommet,
                    tasksDto = new TasksDto2
                    {
                        idTask = a.idTask,
                        idProyect = a.Tasks.idProyect,
                        idUser = a.Tasks.idUser,
                        nameTask = a.Tasks.nameTask,
                        descriptionTask = a.Tasks.descriptionTask,
                        dateTask = a.Tasks.dateTask,
                        dateTaskCompletion = a.Tasks.dateTaskCompletion,
                        state = a.Tasks.state
                    }
                }).ToList()
            }).ToListAsync();

            return Ok(allTasks);
        }



        [HttpGet("GetTask/{idTask}")]
        public async Task<IActionResult> GetTask(int idTask)
        {
            await _operations.GetTask(idTask);

            var task = await _dbcontext.Tasks.Where(a => a.idTask == idTask).Select(a => new TasksDto
            {
                idProyect = a.idProyect,
                idTask = a.idTask,
                idUser = a.idUser,
                nameTask = a.nameTask,
                descriptionTask = a.descriptionTask,
                dateTask = a.dateTask,
                dateTaskCompletion = a.dateTaskCompletion,
                state = a.state,
                User = new UsersCustomDto
                {
                    idUser = a.User.idUser,
                    IdRol = a.User.IdRol,
                    nameUser = a.User.nameUser,
                    emailUser = a.User.emailUser,
                    password = a.User.password
                },
                proyects = new ProyectDto2
                {
                    idProyect = a.idProyect,
                    nameProyect = a.Proyects.nameProyect
                },
                comments = a.Comment.Select(a => new CommentsDto
                {
                    idComment = a.idComment,
                    idTask = a.idTask,
                    descriptionCommet = a.descriptionCommet,
                    tasksDto = new TasksDto2
                    {
                        idTask = a.idTask,
                        idProyect = a.Tasks.idProyect,
                        idUser = a.Tasks.idUser,
                        nameTask = a.Tasks.nameTask,
                        descriptionTask = a.Tasks.descriptionTask,
                        dateTask = a.Tasks.dateTask,
                        dateTaskCompletion = a.Tasks.dateTaskCompletion,
                        state = a.Tasks.state
                    },

                }).ToList()
            }).ToListAsync();

            var tasks = _dbcontext.Tasks.Where(a => a.idTask == idTask).FirstOrDefault();

            if (tasks.dateTask == tasks.dateTaskCompletion)
            {
                tasks.state = "Terminada";
            }

            return Ok(task);
        }

        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateTask(TasksDto2 tasksDto)
        {
            Tasks task = new Tasks()
            {
                descriptionTask = tasksDto.descriptionTask,
                nameTask = tasksDto.nameTask,
                dateTask = tasksDto.dateTask,
                dateTaskCompletion = tasksDto.dateTaskCompletion,
                idProyect = tasksDto.idProyect,
                state = tasksDto.state,
                idUser = tasksDto.idUser
            };

            var result = await _operations.CreateTask(task);

            return Ok(task);
        }

        [HttpPut("UpdateTask/{idTask}")]
        public async Task<bool> UpdateTask(TasksDto2 tasksDto)
        {
            var result = await _operations.UpdateTask(tasksDto);

            return result;
        }

        [HttpDelete("DeleteTask/{idTask}")]
        public async Task<IActionResult> DeleteTask(int idTask)
        {
            var result = await _operations.DeleteTask(idTask);

            return Ok("Tarea Eliminada con exito");
        }
    }
}
