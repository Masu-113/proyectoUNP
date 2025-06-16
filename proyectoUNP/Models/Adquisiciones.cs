using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoUNP.Models
{
    [Table("Adquisiciones")]
    public class Adquisicion
    {
        [Key]
        public int IdAdquisicion { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(20)]
        public string TipoAdquisicion { get; set; }  // "Compra" o "Donación"

        [StringLength(50)]
        public string NumeroFactura { get; set; }

        [Column(TypeName = "decimal")]
        public decimal? Monto { get; set; }

        [ForeignKey("Proveedor")]
        public int? IdProveedor { get; set; }

        [ForeignKey("Empleado")]
        public int? IdEmpleado { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; }

        public Proveedor Proveedor { get; set; }
        public Empleado Empleado { get; set; }
    }
}