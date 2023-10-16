using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Application.DTO.Companhia
{
    public class CompanhiaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? CNPJ { get; set; }
    }
}
