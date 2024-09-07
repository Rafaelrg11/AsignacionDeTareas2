using AsignacionDeTareas2.Controllers;
using AsignacionDeTareas2.Models;
using AsignacionDeTareas2.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using Microsoft.AspNetCore.Mvc;
using AsignacionDeTareas2.DTOs;

namespace AsignacionDeTareas2Testing.ControllerTesting
{
    public class ModuleControllerTesting
    {
        public readonly ModuleOperations _operation;
        public readonly ModuleController _controller;
        private readonly ApplicationDbcontext _context;
        private readonly IDbContextTransaction _transaction;

        public ModuleControllerTesting()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbcontext>()
                .UseNpgsql("Server=localhost;Database=asignacion_tareas;Port=5432;Username=postgres")
                .Options;

            _context = new ApplicationDbcontext(options);

            _operation = new ModuleOperations(_context);
            _controller = new ModuleController(_operation, _context);

            _transaction = _context.Database.BeginTransaction();

            void Dispose()
            {
                _transaction.Rollback();
                _context.Dispose();
            }
        }

        [Fact]
        public async Task GetModules_OK()
        {
            var result = await _controller.GetModules();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetModule_OK()
        {
            var moduleId = _context.Modules.Select(a => a.IdMod).FirstOrDefault();

            var result = await _controller.GetModule(moduleId);

            Assert.NotNull(result);

            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task CreateNotificationb_OK()
        {
            var newModule = new ModuleDto2
            {
                NameMod = "modulo de recreación",
                IdMod = 3
            };

            var result = await _controller.CreateModule(newModule);
            Assert.NotNull(result);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task UpdateNotification_OK()
        {
            var uModule = new ModuleDto2
            {
                IdMod = 3,
                NameMod = "Usuarios"
            };

            var result = await _controller.UpdateModule(uModule);
            Assert.NotNull(result);

            var okResult = Assert.IsType<bool>(result);
            Assert.NotNull(okResult);
        }
    }
}
