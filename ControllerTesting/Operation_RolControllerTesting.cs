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
    public class Operation_RolControllerTesting
    {
        public readonly Operation_RolOperations _operation;
        public readonly Operations_RolController _controller;
        private readonly ApplicationDbcontext _context;
        private readonly IDbContextTransaction _transaction;

        public Operation_RolControllerTesting()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbcontext>()
                .UseNpgsql("Server=localhost;Database=asignacion_tareas;Port=5432;Username=postgres")
                .Options;

            _context = new ApplicationDbcontext(options);

            _operation = new Operation_RolOperations(_context);
            _controller = new Operations_RolController(_context, _operation);

            _transaction = _context.Database.BeginTransaction();

            void Dispose()
            {
                _transaction.Rollback();
                _context.Dispose();
            }
        }

        [Fact]
        public async Task GetOperationRols_OK()
        {
            var result = await _controller.GetOperationsRols();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetOperationRol_OK()
        {
            var opeId = _context.OperationRols.Select(a => a.IdOperationsRol).FirstOrDefault();

            var result = await _controller.GetOperationRol(opeId);

            Assert.NotNull(result);

            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task CreateOperationRol_OK()
        {
            var newOperationRol = new Operations_rolDto2
            {
                IdOperationsRol = 5,
                IdModulo = 1,
                NameOperationRol = "Crear"
            };

            var result = await _controller.CreateOperationRol(newOperationRol);
            Assert.NotNull(result);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task UpdateOperationRol_OK()
        {
            var uOperationRol = new Operations_rolDto2
            {
                IdOperationsRol = 2,
                NameOperationRol = "Ver"
            };

            var result = await _controller.UpdateUpdateOperationRol(uOperationRol);
            Assert.NotNull(result);

            var okResult = Assert.IsType<bool>(result);
            Assert.NotNull(okResult);
        }
    }
}
