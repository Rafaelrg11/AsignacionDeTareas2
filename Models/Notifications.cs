using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AsignacionDeTareas2.Models
{
    public class Notifications
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idNotification { get; set; }
        public string nameNotification { get; set; }
        public string descriptionNotification { get; set; }
        public int idUSer { get; set; }
        public virtual Users User { get; set; }
    }
}
