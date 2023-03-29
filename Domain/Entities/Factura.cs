using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Factura
    {
        [Key]
        public int Pk { get; set; }
        [Required]
        public string RazonSocial { get; set; }
        [Required]
        public string Fecha { get; set; }
        [Required]
        public string RFC { get; set; }

        [ForeignKey("Cliente")]
        [Required]
        public int FkCliente { get; set; }
        [Required]
        public Cliente Cliente { get; set; }
    }
}
