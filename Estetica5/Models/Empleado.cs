using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estetica5.Models
{
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Clave { get; set; }
        public String Horario { get; set; }
        public String Nombre { get; set; }
        public String Telefono { get; set; }
        public IEnumerable<Cita> Citas { get; set; }

    }
}