using CakeUpERP.Application.Interfaces;
using CakeUpERP.Domain.Interfaces.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Application.Service
{
    public class CompanhiaService : ICompanhiaService
    {
        private readonly ICompanhiaRepository _companhiaRepository;

        public CompanhiaService(ICompanhiaRepository companhiaRepository)
        {
            _companhiaRepository = companhiaRepository;
        }

        public bool VerificarCnpjCadastrado(string cnpj)
        {
            if(!Maoli.Cnpj.Validate(cnpj))
                return false;

            return _companhiaRepository.VeririficarCadastroCompanhia(cnpj);            
        }
    }
}
