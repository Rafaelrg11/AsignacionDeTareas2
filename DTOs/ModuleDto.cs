namespace AsignacionDeTareas2.DTOs
{
    public class ModuleDto
    {
        public int IdMod { get; set; }
        public string NameMod { get; set; }
        public virtual ICollection<Operations_rolDto2> Operations_RolDtos { get; set; } = new List<Operations_rolDto2>();  
    }
}
