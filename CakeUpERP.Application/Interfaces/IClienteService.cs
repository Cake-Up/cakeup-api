using CakeUpERP.Application.DTO.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Application.Interfaces
{
    public interface IClienteService
    {
        Task CadastrarCliente(CadastrarClienteModel cliente);
    }
}
