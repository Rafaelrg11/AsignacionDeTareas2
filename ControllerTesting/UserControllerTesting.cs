using AsignacionDeTareas2.Controllers;
using AsignacionDeTareas2.Models;
using AsignacionDeTareas2.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using Microsoft.AspNetCore.Mvc;
using AsignacionDeTareas2.DTOs;
using Microsoft.Extensions.Configuration;


namespace AsignacionDeTareas2Testing.ControllerTesting
{
    public class UserControllerTesting
    {
        private readonly UsersController _controller;
        private readonly UsersOperations _operations;
        private readonly Mock<IConfiguration> mock;
        private readonly ApplicationDbcontext _context;
        private readonly IDbContextTransaction _transaction;
        public UserControllerTesting()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbcontext>()
                .UseNpgsql("Server=localhost;Database=asignacion_tareas;Port=5432;Username=postgres")
                .Options;

            _context = new ApplicationDbcontext(options);

            _operations = new UsersOperations(_context);
            mock = new Mock<IConfiguration>();
            mock.Setup(config => config.GetSection("Jwt").GetSection("Key").Value);
            _controller = new UsersController(mock.Object, _operations, _context);

            _transaction = _context.Database.BeginTransaction();

            void Dispose()
            {
                _transaction.Rollback();
                _context.Dispose();
            }
        }

        [Fact]
        public async Task GetAllUsers_OK()
        {
            var result = await _controller.GetUsers();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetUser_OK()
        {
            var UserId = _context.Users.Select(a => a.idUser).FirstOrDefault();

            var result = await _controller.GetUSer(UserId);

            Assert.NotNull(result);

            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task CreateUser_OK()
        {
            var newuser = new UserDto2
            {
                idUser = 5,
                IdRol = 1,
                nameUser = "Rafael",
                emailUser = "Rrg@gmail.com",
                password = 12345
            };

            var result = await _controller.CreateUser(newuser);
            Assert.NotNull(result);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task UpdateUser_OK()
        {
            var newuser = new UserDto2
            {
                idUser = 5,
                IdRol = 1,
                nameUser = "Roberto",
                emailUser = "Rr@gmail.com",
                password = 123456
            };

            var result = await _controller.UpdateUser(newuser);
            Assert.NotNull(result);

            var okResult = Assert.IsType<bool>(result);
            Assert.NotNull(okResult);
        }


    }
}