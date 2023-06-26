using CakeUpERP.Application.Interfaces;
using CakeUpERP.Domain.Interfaces.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Application.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
        { 
            _repository = repository;
        }
    }
}
