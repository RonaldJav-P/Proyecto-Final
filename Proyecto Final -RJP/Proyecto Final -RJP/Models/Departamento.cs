using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalRJP.Models
{
    public class Departamento
    {
        [Key]
        public int DepartamentoID { get; set; }

        [Required(ErrorMessage = "El nombre del departamento es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del departamento no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; }

        public ICollection<Empleado>? Empleados { get; set; }
    }
}
