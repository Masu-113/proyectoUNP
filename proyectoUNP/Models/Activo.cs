using proyectoUNP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoUNP.Models
{
    [Table("Activos")]
    public class Activos
    {
        [Key]
        public int IdActivos { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

        [ForeignKey("TipoDeActivo")]
        public int IdTipo { get; set; }
        public virtual TipoDeActivo TipoDeActivo { get; set; }

        [ForeignKey("Marca")]
        public int IdMarca { get; set; }
        public virtual Marca Marca { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{3}-[0-9]{4}-[A-Z]{3}$", ErrorMessage = "Formato inválido: AAA-0000-AAA")]
        [StringLength(12)]
        public string NumeroSerie { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0.01, 999999999999.99, ErrorMessage = "El costo debe ser mayor que cero.")]
        public decimal Costo { get; set; }


        [Required]
        public DateTime FechaCompra { get; set; }

        public bool Garantia { get; set; } = true;

        [ForeignKey("EstadoActual")]
        public int IdEstAct { get; set; }
        public virtual EstadoActual EstadoActual { get; set; }

        [ForeignKey("Proveedor")]
        public int IdProveedor { get; set; }
        public virtual Proveedor Proveedor { get; set; }

        [ForeignKey("Empleado")]
        public int? IdEmpleado { get; set; }
        public virtual Empleado Empleado { get; set; }

        [ForeignKey("Ubicacion")]
        public int? IdUbicacion { get; set; }
        public virtual Ubicacion Ubicacion { get; set; }


        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaModificacion { get; set; }

        [StringLength(30)]
        public string UsuarioModificacion { get; set; }
    }
}
