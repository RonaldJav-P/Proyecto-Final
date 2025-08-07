using ProyectoFinalRJP.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalRJP.Models
{
    public class Empleado
    {
        [Key]
        public int EmpleadoID { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El departamento es obligatorio.")]
        public int DepartamentoID { get; set; }

        [Required(ErrorMessage = "El cargo es obligatorio.")]
        public int CargoID { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido.")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "El salario es obligatorio.")]
        [Range(1000, 1000000, ErrorMessage = "El salario debe estar entre 1,000 y 1,000,000.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "Debe indicar si el empleado está activo o no.")]
        public bool Estado { get; set; }

        public Departamento? Departamento { get; set; }
        public Cargo? Cargo { get; set; }

        [NotMapped]
        public string TiempoEnEmpresa
        {
            get
            {
                var tiempo = DateTime.Now - FechaInicio;
                int años = tiempo.Days / 365;
                int meses = (tiempo.Days % 365) / 30;
                return $"{años} años y {meses} meses";
            }
        }

        [NotMapped]
        public decimal AFP => Math.Round(Salario * 0.0287m, 2);

        [NotMapped]
        public decimal ARS => Math.Round(Salario * 0.0304m, 2);

        [NotMapped]
        public decimal ISR
        {
            get
            {
                if (Salario <= 34685) return 0;
                else if (Salario <= 52027) return Math.Round(Salario * 0.15m, 2);
                else return Math.Round(Salario * 0.25m, 2);
            }
        }
    }
}
