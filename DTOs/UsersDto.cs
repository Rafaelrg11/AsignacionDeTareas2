namespace AsignacionDeTareas2.DTOs
{
    public class UsersDto
    {
        public int idUser { get; set; }
        public int password { get; set; }
        public string emailUser { get; set; }
        public string nameUser { get; set; }
        public int IdRol { get; set; }
        public ICollection<TasksDto2> tasksDto2 { get; set; } = new List<TasksDto2>();
        public RolDto2 rolDto { get; set; }
    }
}
