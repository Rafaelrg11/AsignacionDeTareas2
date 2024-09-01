using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AsignacionDeTareas2.Models
{
    public class Module
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMod { get; set; }
        public string NameMod { get; set; }
        public virtual ICollection<Operations_Rol> OperationsRol { get; set; } = new List<Operations_Rol>();
    }
}
