using System.ComponentModel.DataAnnotations;

namespace ApiExamen.Models
{
    public class Tarea
    {
        [Key]
        public int ID { get; set; }


        public string Nombre { get; set; }


        public string Estado { get; set; }


        public string Tareas { get; set; }
    }
}
