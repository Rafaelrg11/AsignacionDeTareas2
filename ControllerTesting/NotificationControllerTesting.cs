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
    public class NotificationControllerTesting
    {
        public readonly NotificationOperations _operation;
        public readonly NotificationsController _controller;
        private readonly ApplicationDbcontext _context;
        private readonly IDbContextTransaction _transaction;

        public NotificationControllerTesting()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbcontext>()
                .UseNpgsql("Server=localhost;Database=asignacion_tareas;Port=5432;Username=postgres")
                .Options;

            _context = new ApplicationDbcontext(options);

            _operation = new NotificationOperations(_context);
            _controller = new NotificationsController(_operation, _context);

            _transaction = _context.Database.BeginTransaction();

            void Dispose()
            {
                _transaction.Rollback();
                _context.Dispose();
            }
        }

        [Fact]
        public async Task GetNotifications_OK()
        {
            var result = await _controller.GetNotifications();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetNotification_OK()
        {
            var operacionId = _context.Notifications.Select(a => a.idNotification).FirstOrDefault();

            var result = await _controller.GetNotification(operacionId);

            Assert.NotNull(result);

            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task CreateNotification_OK()
        {
            var newNotification = new NotificationsDto2
            {
                idNotification = 2,
                idUser = 9,
                nameNotification = "Notification Prueba",
                descriptionNotification = "Esta es una notificaion de prueba"
            };

            var result = await _controller.CreateNotification(newNotification);
            Assert.NotNull(result);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task UpdateNotification_OK()
        {
            var uNotification = new NotificationsDto2
            {
                idNotification = 3,
                idUser = 4,
                nameNotification = "Prueba de todo",
                descriptionNotification = "Esta es una notificacion de prueba"
            };

            var result = await _controller.UpdateNotification(uNotification);
            Assert.NotNull(result);

            var okResult = Assert.IsType<bool>(result);
            Assert.NotNull(okResult);
        }
    }
}
