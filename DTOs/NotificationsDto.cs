﻿namespace AsignacionDeTareas2.DTOs
{
    public class NotificationsDto
    {
        public int idNotification { get; set; }
        public int idUser { get; set; }
        public string nameNotification { get; set; }
        public string descriptionNotification { get; set; }
        public UserDto2 UserDto { get; set; }
    }
}
