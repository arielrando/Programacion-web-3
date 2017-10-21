using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrabajoPracticoGrupo10.Models
{
    public class CustomDateRangeAttribute : RangeAttribute
    {
        public CustomDateRangeAttribute() : base(typeof(DateTime), DateTime.Now.ToString(), DateTime.MaxValue.ToString())
        { }
    }

    public class Paquete
    {
        [Required(ErrorMessage = "Campo Obligatorio"), StringLength(15, ErrorMessage = "Debe tener entre 5 y 15 caracteres", MinimumLength = 5)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio"), StringLength(15, ErrorMessage = "Debe tener entre 5 y 15 caracteres", MinimumLength = 5)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Foto { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio"), DataType(DataType.Date)]
        [CustomDateRange]
        public string FechaInicio { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio"), DataType(DataType.Date)]
        public string FechaFin { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public bool Destacado { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public int LugaresDisponibles { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public int PrecioPorPersona { get; set; }
    }
}