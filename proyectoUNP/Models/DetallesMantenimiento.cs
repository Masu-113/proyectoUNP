using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoUNP.Models
{

    [Table("DetallesMantenimiento")]
    public class DetallesMantenimiento
    {
        [Key]
        public int IdDM { get; set; }

        [Required]
        [StringLength(100)]
        public string DetallesDelMantenimiento { get; set; }

        // Relación
        public virtual ICollection<TipoMantenimiento> TipoMantenimientos { get; set; }
    }

}