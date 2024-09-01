using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AsignacionDeTareas2.Models
{
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRol { get; set; }
        public string nombre { get; set; }
        public virtual ICollection<Users> Users { get; set; } = new List<Users>();
        public virtual ICollection<Operaciones> Operacion { get; set; } = new List<Operaciones>();
    }
}
