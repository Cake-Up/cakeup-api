using CakeUpERP.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Application.DTO.Companhia
{
    public class CriarCompanhiaDTO
    {
        public string Nome { get; set; }
        public string? Cnpj { get; set; }
        public string? NomeSite { get; set; }

        public CriarCompanhiaDTO() { }
        public CriarCompanhiaDTO(string nome, string? cnpj, string? nomeSite)
        {
            Nome = nome;
            if(!string.IsNullOrEmpty(cnpj) && Maoli.Cnpj.Validate(cnpj))
                Cnpj = cnpj;
            
            NomeSite = nomeSite;
        }
    }
}
