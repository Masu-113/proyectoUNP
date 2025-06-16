using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoUNP.Models
{
    [Table("Marca")]
    public class Marca
    {
        [Key]
        public int IdMarca { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public virtual ICollection<Activos> Activos { get; set; }
    }
}

