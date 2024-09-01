using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AsignacionDeTareas2.Models
{
    public class Operaciones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOperaciones { get; set; }
        public int IdRol { get; set; }
        public int IdOperationRol { get; set; }
        public virtual Rol Rol { get; set; }
        public virtual Operations_Rol OperationsRol { get; set; }
    }
}
