using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoUNP.Models
{
    [Table("Universidades")]
    public class Universidad
    {
        [Key]
        public int IdUniversidad { get; set; }

        [Required, MaxLength(50)]
        public string Nombre { get; set; }

        public int IdBarrio { get; set; }

        [MaxLength(100)]
        public string Direccion { get; set; }

        public virtual ICollection<Escuela> Escuelas { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}