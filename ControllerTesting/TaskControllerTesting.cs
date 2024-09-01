using AsignacionDeTareas2.Controllers;
using AsignacionDeTareas2.Models;
using AsignacionDeTareas2.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Mvc;
using AsignacionDeTareas2.DTOs;

namespace AsignacionDeTareas2Testing.ControllerTesting
{
    public class TaskControllerTesting
    {
        private readonly TasksOperations _operationsT;
        private readonly TasksController _controllerT;
        private readonly ApplicationDbcontext _context;
        private readonly IDbContextTransaction _transaction;

        public TaskControllerTesting()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbcontext>()
                .UseNpgsql("Server=localhost;Database=asignacion_tareas;Port=5432;Username=postgres")
                .Options;

            _context = new ApplicationDbcontext(options);
            _operationsT = new TasksOperations(_context);
            _controllerT = new TasksController(_operationsT, _context);

            _transaction = _context.Database.BeginTransaction();

            void Dispose()
            {
                _transaction.Rollback();
                _context.Dispose();
            }
        }

        [Fact]
        public async Task GetTasks_OK()
        {
            var result = await _controllerT.GetTasks();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetTask_OK()
        {
            var tasksId = _context.Tasks.Select(a => a.idTask).FirstOrDefault();

            var result = await _controllerT.GetTask(tasksId);

            Assert.NotNull(result);

            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task CreateTask_OK()
        {
            var ope = new TasksDto2
            {
                nameTask = "Tarea de pruebaxd",
                descriptionTask = "Esta es una tarea de prueba",
                dateTask = DateTime.UtcNow,
                dateTaskCompletion = DateTime.UtcNow,
                state = "Pendiente",
                idProyect = 2,
                idUser = 5,
                idTask = 0
            };

            var result = await _controllerT.CreateTask(ope);
            Assert.NotNull(result);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }
        [Fact]
        public async Task UpdateTask_OK()
        {
            var newTask = new TasksDto2
            {
                nameTask = "Tarea de prueba otra vez, mondáaaaa",
                descriptionTask = "Esta es una tarea de prueba",
                dateTask = DateTime.UtcNow,
                dateTaskCompletion = DateTime.UtcNow,
                state = "Pendiente",
                idProyect = 2,
                idTask = 0,
                idUser = 5

            };

            var result = await _controllerT.UpdateTask(newTask);
            Assert.NotNull(result);

            var okResult = Assert.IsType<bool>(result);
            Assert.NotNull(okResult);
        }
    }
}
