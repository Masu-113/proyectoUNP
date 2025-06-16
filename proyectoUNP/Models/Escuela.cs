using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoUNP.Models
{
    public class Escuela
    {
        [Key]
        public int IdEscuela { get; set; }

        [Required, MaxLength(100)]
        public string NombreEscuela { get; set; }

        public int IdUniversidad { get; set; }

        [ForeignKey("IdUniversidad")]
        public virtual Universidad Universidad { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }

}