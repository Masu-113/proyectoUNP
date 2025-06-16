using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoUNP.Models
{
    [Table("Proveedor")]
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        [Required]
        public int IdBarrio { get; set; }

        [ForeignKey("IdBarrio")]
        public virtual Barrio Barrio { get; set; }
    }
}
