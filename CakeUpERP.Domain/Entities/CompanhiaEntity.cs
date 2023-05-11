using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Domain.Entities
{
    public class CompanhiaEntity : EntityBase
    {
        public string Nome { get; set; }
        public string? NomeSite { get; set; }
        public string? Cnpj { get; set; }
        public string? UrlImagem { get; set; }
    }
}
