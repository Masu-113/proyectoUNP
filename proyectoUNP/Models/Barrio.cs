using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoUNP.Models
{
    public class Barrio
    {
        [Key]
        public int IdBarrio { get; set; }

        [Required]
        [StringLength(30)]
        public string NombreBarrio { get; set; }

        [Required]
        public int IdMunicipio { get; set; }

        [ForeignKey("IdMunicipio")]
        public virtual Municipio Municipio { get; set; }

        public virtual ICollection<Proveedor> Proveedores { get; set; }
        //public virtual ICollection<Universidad> Universidades { get; set; }
    }
}
