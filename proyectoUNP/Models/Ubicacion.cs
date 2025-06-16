using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoUNP.Models
{
    [Table("Ubicaciones")]
    public class Ubicacion
    {
        [Key]
        public int IdUbicacion { get; set; }

        public string Direccion { get; set; }

        public int IdEscuela { get; set; }

        [ForeignKey("IdEscuela")]
        public virtual Escuela Escuela { get; set; }
    }
}