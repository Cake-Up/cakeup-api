using CakeUpERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Application.DTO.Cliente
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<ObservacaoClienteDTO> ObservacaoCliente { get; set; }

        public ClienteDTO() { }
        public ClienteDTO(ClienteEntity cliente)
        {
            Id = cliente.Id;
            Nome = cliente.Nome;
            ObservacaoCliente = cliente.ObservacaoClienteEntities
                .Select(k => new ObservacaoClienteDTO(k))
                .ToList();
        }


    }
}
