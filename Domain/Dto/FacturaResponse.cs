using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class FacturaResponse
    {
        public string RazonSocial { get; set; }
        
        public string Fecha { get; set; }
        
        public string RFC { get; set; }

        public int FkCliente { get; set; }
    }
}
