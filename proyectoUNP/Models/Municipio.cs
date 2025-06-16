using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace proyectoUNP.Models
{
    public class Municipio
    {
        [Key]
        public int IdMun { get; set; }

        [Required]
        [StringLength(30)]
        public string NombreMun { get; set; }

        [Required]
        public int IdDepartamento { get; set; }

        [ForeignKey("IdDepartamento")]
        public virtual Departamento Departamento { get; set; }

        public virtual ICollection<Barrio> Barrios { get; set; }
    }
}
