using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AsignacionDeTareas2.Models
{
    public class AuxiliarT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idAuxiliar { get; set; }
        public int idUser { get; set; }
        public int idProyect { get; set; }
        public virtual Users User { get; set; }
        public virtual Proyects Proyect { get; set; }
    }
}
