using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoUNP.Models
{
    [Table("EstadoActual")]
    public class EstadoActual
    {
        [Key]
        public int IdEstAct { get; set; }

        [Required]
        [StringLength(30)]
        public string Estado_Actual { get; set; }
    }
}
