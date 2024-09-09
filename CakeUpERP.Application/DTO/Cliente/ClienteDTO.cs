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
        public int IdCompanhia { get; set; }
        public string Nome { get; set; }

        public ClienteDTO() { }
        public ClienteDTO(ClienteEntity cliente)
        {
            Id = cliente.Id;
            Nome = cliente.Nome;
            IdCompanhia = cliente.IdCompanhia;
        }


    }
}
