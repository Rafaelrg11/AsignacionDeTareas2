using AsignacionDeTareas2.DTOs;
using AsignacionDeTareas2.Models;
using AsignacionDeTareas2.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AsignacionDeTareas2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationsController : Controller
    {
        public ApplicationDbcontext _dbcontext;

        public NotificationOperations _operations;
        public NotificationsController(NotificationOperations notification, ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
            _operations = notification;
        }

        [HttpGet("GetNotifications")]
        public async Task<IActionResult> GetNotifications()
        {
            await _operations.GetNotifications();

            var allNotifications = await _dbcontext.Notifications.Select(a => new NotificationsDto
            {
                descriptionNotification = a.descriptionNotification,
                nameNotification = a.nameNotification,
                idNotification = a.idNotification,
                idUser = a.idUSer,
                UserDto = new UserDto2
                {
                    idUser = a.User.idUser,
                    IdRol = a.User.IdRol,
                    emailUser = a.User.emailUser,
                    nameUser = a.User.nameUser,
                    password = a.User.password,
                }
            }).ToListAsync();

            return Ok(allNotifications);
        }

        [HttpGet("GetNotification/{idNotifi}")]
        public async Task<IActionResult> GetNotification(int idNotifi)
        {
            await _operations.GetNotification(idNotifi);

            var notifi = await _dbcontext.Notifications.Where(a => a.idNotification == idNotifi).Select(a => new NotificationsDto
            {
                descriptionNotification = a.descriptionNotification,
                nameNotification = a.nameNotification,
                idNotification = a.idNotification,
                idUser = a.idUSer,
                UserDto = new UserDto2
                {
                    idUser = a.User.idUser,
                    IdRol = a.User.IdRol,
                    emailUser = a.User.emailUser,
                    nameUser = a.User.nameUser,
                    password = a.User.password
                }
            }).ToListAsync();

            return Ok(notifi);
        }

        [HttpPost("CreateNotification")]
        public async Task<IActionResult> CreateNotification(NotificationsDto2 notifications)
        {
            Notifications notifi = new Notifications()
            {
                nameNotification = notifications.nameNotification,
                descriptionNotification = notifications.descriptionNotification,
                idUSer = notifications.idUser
            };

            var operations = await _operations.CreateNotification(notifi);

            return Ok(operations);
        }

        [HttpPut("UpdateNotification/{idNotification}")]
        public async Task<bool> UpdateNotification(NotificationsDto2 notificationsDto)
        {
            var result = await _operations.UpdateNotification(notificationsDto);

            return result;
        }

        [HttpDelete("DeleteNotification/{idNotification}")]
        public async Task<bool> DeleteNotification(int idNotification)
        {
            var result = await _operations.DeleteNotification(idNotification);

            return result;
        }
    }
}
