using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoUNP.Models
{
    [Table("TipoUsers")]
    public class TipoUser
    {
        [Key]
        public int IdTipoUser { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        // Relación con los usuarios
        public virtual ICollection<User> Users { get; set; }
    }
}