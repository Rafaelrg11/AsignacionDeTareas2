using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AsignacionDeTareas2.Models
{
    public class Operations_Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOperationsRol { get; set; }
        public string NameOperationRol { get; set; }
        public int IdModulo { get; set; }
        public virtual Module Module { get; set; }
        public virtual ICollection<Operaciones> Operaciones { get; set; } = new List<Operaciones>();
    }
}
