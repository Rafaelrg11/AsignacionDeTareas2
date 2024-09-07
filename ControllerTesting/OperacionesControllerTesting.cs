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
    public class OperacionesControllerTesting
    {
        public readonly OperacionesOperation _operation;
        public readonly OperacionesController _controller;
        private readonly ApplicationDbcontext _context;
        private readonly IDbContextTransaction _transaction;

        public OperacionesControllerTesting()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbcontext>()
                .UseNpgsql("Server=localhost;Database=asignacion_tareas;Port=5432;Username=postgres")
                .Options;

            _context = new ApplicationDbcontext(options);

            _operation = new OperacionesOperation(_context);
            _controller = new OperacionesController(_context, _operation);

            _transaction = _context.Database.BeginTransaction();

            void Dispose()
            {
                _transaction.Rollback();
                _context.Dispose();
            }
        }

        [Fact]
        public async Task GetOperaciones_OK()
        {
            var result = await _controller.GetOperaciones();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetOperacion_OK()
        {
            var operacionId = _context.Operations.Select(a => a.IdOperaciones).FirstOrDefault();

            var result = await _controller.GetOperacion(operacionId);

            Assert.NotNull(result);

            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task CreateOperacion_OK()
        {
            var newOperacion = new OperacionesDto2
            {
                IdOperaciones = 3,
                IdOperationRol = 2,
                IdRol = 2
            };

            var result = await _controller.CreateOperacion(newOperacion);
            Assert.NotNull(result);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task UpdateOperacion_OK()
        {
            var uOperacion = new OperacionesDto2
            {
                IdOperaciones = 2,
                IdRol = 3,
                IdOperationRol = 2
            };

            var result = await _controller.UpdateOperacion(uOperacion);
            Assert.NotNull(result);

            var okResult = Assert.IsType<bool>(result);
            Assert.NotNull(okResult);
        }
    }
}
