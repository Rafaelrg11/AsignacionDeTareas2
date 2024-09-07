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
    public class AuxiliarTControllerTesting
    {
        public readonly AuxiliarTOperations _operation;
        public readonly AuxiliarTController _controller;
        private readonly ApplicationDbcontext _context;
        private readonly IDbContextTransaction _transaction;

        public AuxiliarTControllerTesting()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbcontext>()
                .UseNpgsql("Server=localhost;Database=asignacion_tareas;Port=5432;Username=postgres")
                .Options;

            _context = new ApplicationDbcontext(options);

            _operation = new AuxiliarTOperations(_context);
            _controller = new AuxiliarTController(_context, _operation);

            _transaction = _context.Database.BeginTransaction();

            void Dispose()
            {
                _transaction.Rollback();
                _context.Dispose();
            }
        }

        [Fact]
        public async Task GetAuxiliarTs_OK()
        {
            var result = await _controller.GetAuxiliars();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAuxiliarT_OK()
        {
            var auxiliarId = _context.AuxiliarTs.Select(a => a.idAuxiliar).FirstOrDefault();

            var result = await _controller.GetAuxiliar(auxiliarId);

            Assert.NotNull(result);

            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task CreateAuxiliar_OK()
        {
            var newAuxiliar = new AuxiliarTDto
            {
                idAuxiliar = 1,
                idProyect = 2,
                idUser = 6,
            };

            var result = await _controller.CreateAuxiliar(newAuxiliar);
            Assert.NotNull(result);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task UpdateAuxiliar_OK()
        {
            var uAuxiliar = new AuxiliarTDto
            {
                idAuxiliar = 1,
                idProyect = 2,
                idUser = 3
            };

            var result = await _controller.UpdateAuxiliar(uAuxiliar);
            Assert.NotNull(result);

            var okResult = Assert.IsType<bool>(result);
            Assert.NotNull(okResult);
        }
    }
}
