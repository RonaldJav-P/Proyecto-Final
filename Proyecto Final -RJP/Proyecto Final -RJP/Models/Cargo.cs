using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalRJP.Models
{
    public class Cargo
    {
        [Key]
        public int CargoID { get; set; }

        [Required(ErrorMessage = "El nombre del cargo es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del cargo no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; }

        public ICollection<Empleado>? Empleados { get; set; }
    }
}
