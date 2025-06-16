using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace proyectoUNP.Models
{
    public class Departamento
    {
        [Key]
        public int IdDep { get; set; }

        [Required]
        [StringLength(30)]
        public string NombreDep { get; set; }

        // Navegación
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
