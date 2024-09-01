namespace AsignacionDeTareas2.DTOs
{
    public class OperacionesDto
    {
        public int IdOperaciones { get; set; }
        public int IdRol { get; set; }
        public int IdOperationRol { get; set; }
        public RolDto2 Rol { get; set; }
        public Operations_rolDto2 operations_Rol { get; set; }
    }
}
