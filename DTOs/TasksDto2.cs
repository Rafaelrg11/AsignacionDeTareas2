namespace AsignacionDeTareas2.DTOs
{
    public class TasksDto2
    {
        public int idTask { get; set; }
        public int idProyect { get; set; }
        public int idUser { get; set; }
        public string nameTask { get; set; }
        public string descriptionTask { get; set; }
        public DateTime dateTask { get; set; }
        public DateTime dateTaskCompletion { get; set; }
        public string state { get; set; }
    }
}
