using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoUNP.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int IdUsers { get; set; }

        [Required]
        public int IdTipoUsers { get; set; }

        [Required]
        [StringLength(30)]
        public string NombreUsers { get; set; }

        [Required]
        [StringLength(10)]
        public string Contraseña { get; set; }

        // Relación con TipoUser
        [ForeignKey("IdTipoUsers")]
        public virtual TipoUser TipoUser { get; set; }
    }

}