using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estetica5.Models
{
    public class Cita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
     
        [DataType(DataType.Time)]
        public DateTime Hora { get; set; }
        public String Nombre { get; set; }
        public String Telefono { get; set; }

        [ForeignKey("Servicio")]
        public int Id_Servicio { get; set; }
        [ForeignKey("Empleado")]
        public int Id_Empleado { get; set; }


        public Servicio Servicio { get; set; }
        public Empleado Empleado { get; set; }

    }
}