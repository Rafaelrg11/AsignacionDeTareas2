using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AsignacionDeTareas2.Models
{
    public class Comments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idComment { get; set; }
        public int idTask { get; set; }
        public string descriptionCommet { get; set; }
        public virtual Tasks Tasks { get; set; }
    }
}
