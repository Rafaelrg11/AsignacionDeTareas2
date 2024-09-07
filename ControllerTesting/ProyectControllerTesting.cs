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
    public class ProyectControllerTesting
    {
        public readonly ProyectsOperations _operation;
        public readonly ProyectsController _controller;
        private readonly ApplicationDbcontext _context;
        private readonly IDbContextTransaction _transaction;

        public ProyectControllerTesting()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbcontext>()
                .UseNpgsql("Server=localhost;Database=asignacion_tareas;Port=5432;Username=postgres")
                .Options;

            _context = new ApplicationDbcontext(options);

            _operation = new ProyectsOperations(_context);
            _controller = new ProyectsController(_operation, _context);

            _transaction = _context.Database.BeginTransaction();

            void Dispose()
            {
                _transaction.Rollback();
                _context.Dispose();
            }
        }

        [Fact]
        public async Task GetProyects_OK()
        {
            var result = await _controller.GetProyects();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetProyect_OK()
        {
            var UserId = _context.Proyects.Select(a => a.idProyect).FirstOrDefault();

            var result = await _controller.GetProyect(UserId);

            Assert.NotNull(result);

            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task CreateProyect_OK()
        {
            var newProyect = new ProyectDto2
            {
                nameProyect = "Proyecto de prueba para saber si esta joda sirve",
                idProyect = 0,
            };

            var result = await _controller.CreateProyect(newProyect);
            Assert.NotNull(result);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task UpdateProyect_OK()
        {
            var uProyect = new ProyectDto2
            {
                idProyect = 4,
                nameProyect = "Proyecto de prueba para probar si esto sirven Mondáaaaa"
            };

            var result = await _controller.UpdateProyect(uProyect);
            Assert.NotNull(result);

            var okResult = Assert.IsType<bool>(result);
            Assert.NotNull(okResult);
        }
    }
}
