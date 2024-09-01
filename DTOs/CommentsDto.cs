namespace AsignacionDeTareas2.DTOs
{
    public class CommentsDto
    {
        public int idComment { get; set; }
        public int idTask { get; set; }
        public string descriptionCommet { get; set; }
        public TasksDto2 tasksDto { get; set; }
    }
}
