using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AsignacionDeTareas2.Models
{
    public class Proyects
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProyect { get; set; }
        public string nameProyect { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
        public virtual ICollection<AuxiliarT> AuxiliarT { get; set; } = new List<AuxiliarT>();
    }
}
