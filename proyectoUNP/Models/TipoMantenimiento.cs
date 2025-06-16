using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoUNP.Models
{

    [Table("TipoMantenimiento")]
    public class TipoMantenimiento
    {
        [Key]
        public int IdTM { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

        [ForeignKey("DetallesMantenimiento")]
        public int IdDetallesMantenimiento { get; set; }

        public virtual DetallesMantenimiento DetallesMantenimiento { get; set; }

        // Relación
        public virtual ICollection<Mantenimiento> Mantenimientos { get; set; }
    }

}