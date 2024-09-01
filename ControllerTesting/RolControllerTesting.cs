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
    public class RolControllerTesting
    {
        public readonly RolOperation _operation;
        public readonly RolController _controller;
        private readonly ApplicationDbcontext _context;
        private readonly IDbContextTransaction _transaction;

        public RolControllerTesting()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbcontext>()
                .UseNpgsql("Server=localhost;Database=asignacion_tareas;Port=5432;Username=postgres")
                .Options;

            _context = new ApplicationDbcontext(options);

            _operation = new RolOperation(_context);
            _controller = new RolController(_context, _operation);

            _transaction = _context.Database.BeginTransaction();

            void Dispose()
            {
                _transaction.Rollback();
                _context.Dispose();
            }
        }

        [Fact]
        public async Task GetRols_OK()
        {
            var result = await _controller.GetRols();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetRol_OK()
        {
            var rolId = _context.Rols.Select(a => a.IdRol).FirstOrDefault();

            var result = await _controller.GetRol(rolId);

            Assert.NotNull(result);

            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.NotNull(okResult);
        }

        [Fact]
        public async Task CreateRol_OK()
        {
            var newRol = new RolDto2
            {
                IdRol = 3,
                nombre = "Vendedor"
            };

            var result = await _controller.CreateRol(newRol);
            Assert.NotNull(result);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task UpdateRol_OK()
        {
            var uRol = new RolDto2
            {
                IdRol = 3,
                nombre = "Mercaderista"
            };

            var result = await _controller.UpdateRol(uRol);
            Assert.NotNull(result);

            var okResult = Assert.IsType<bool>(result);
            Assert.NotNull(okResult);
        }
    }
}
