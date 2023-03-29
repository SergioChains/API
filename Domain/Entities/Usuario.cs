using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int Pk { get; set; }
        [Required]
        public string User { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }

        [ForeignKey("Empleado")]
        [Required]
        public int FkEmpleado { get; set; }

        [ForeignKey("Rol")]
        [Required]
        public int FkRol { get; set; }

        public Empleado Empleado { get; set; }
        public Rol Rol { get; set; }

    }
}
