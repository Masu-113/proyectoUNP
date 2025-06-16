using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoUNP.Models
{
    [Table("TipoDeActivo")]
    public class TipoDeActivo
    {
        [Key]
        public int IdTipo { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

        public virtual ICollection<Activos> Activos { get; set; }
    }
}

    
