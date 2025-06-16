using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoUNP.Models
{
    [Table("Empleados")]
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }

        [Required, MaxLength(30)]
        public string PNU { get; set; }

        [MaxLength(30)]
        public string SNU { get; set; }

        [Required, MaxLength(30)]
        public string PAU { get; set; }

        [MaxLength(30)]
        public string SAU { get; set; }

        [Required, StringLength(16)]
        [RegularExpression("[0-9]{3}-[0-9]{6}-[0-9]{4}[A-Z]", ErrorMessage = "Formato de cédula incorrecto")]
        public string Cedula { get; set; }

        public int IdUniversidad { get; set; }
        public int? IdEscuela { get; set; }
        public int IdCargo { get; set; }

        [ForeignKey("IdUniversidad")]
        public virtual Universidad Universidad { get; set; }

        [ForeignKey("IdEscuela")]
        public virtual Escuela Escuela { get; set; }

        [ForeignKey("IdCargo")]
        public virtual Cargo Cargo { get; set; }

        public int Estado { get; set; } = 1;
    }
}