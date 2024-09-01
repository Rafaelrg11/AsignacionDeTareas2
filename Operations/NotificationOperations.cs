using AsignacionDeTareas2.DTOs;
using AsignacionDeTareas2.Models;
using Microsoft.EntityFrameworkCore;

namespace AsignacionDeTareas2.Operations
{
    public class NotificationOperations
    {
        public ApplicationDbcontext _context;
        public NotificationOperations(ApplicationDbcontext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<List<Notifications>> GetNotifications()
        {
            var result = await _context.Notifications.AsNoTracking().ToListAsync();

            return result;
        }
        public async Task<Notifications> GetNotification(int idNotification)
        {
            var result = await _context.Notifications.FindAsync(idNotification);

            return result;
        }

        public async Task<Notifications> CreateNotification(Notifications notifications)
        {
            var result = await _context.Notifications.AddAsync(notifications);

            await _context.SaveChangesAsync();

            return notifications;
        }

        public async Task<bool> UpdateNotification(NotificationsDto2 notificationsDto)
        {
            Notifications? notifications = await _context.Notifications.FindAsync(notificationsDto.idNotification);
            if (notifications != null)
            {
                notifications.descriptionNotification = notificationsDto.descriptionNotification;
                notifications.nameNotification = notificationsDto.nameNotification;
                notifications.idUSer = notificationsDto.idUser;

                await _context.SaveChangesAsync();
            }
            return true;
        }
        public async Task<bool> DeleteNotification(int idNotification)
        {
            var result = await _context.Notifications.FindAsync(idNotification);
            if (result == null)
            {
                return false;
            }

            _context.Notifications.Remove(result);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
