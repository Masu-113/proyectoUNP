using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoUNP.Models
{
    [Table("Cargos")]
    public class Cargo
    {
        [Key]
        public int IdCargo { get; set; }

        [Required, MaxLength(100)]
        public string NombreCargo { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }

}