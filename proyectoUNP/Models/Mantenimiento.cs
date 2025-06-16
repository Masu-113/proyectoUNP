using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoUNP.Models
{

    [Table("Mantenimientos")]
    public class Mantenimiento
    {
        [Key]
        public int IdMantenimiento { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Fecha_Mantenimiento { get; set; } = DateTime.Now;

        public int IdTM { get; set; }
        [ForeignKey("IdTM")]
        public virtual TipoMantenimiento TipoMantenimiento { get; set; }

        public int IdActivos { get; set; }
        [ForeignKey("IdActivos")]  // Aquí estaba mal antes
        public virtual Activos Activo { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public float Costo { get; set; }
    }

}