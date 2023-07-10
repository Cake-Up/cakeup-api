using CakeUpERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Application.DTO.Cliente
{
    public class DadosObservacaoCliente
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime DataObservacao { get; set; }
        public string Observacao { get; set; }
    
        public DadosObservacaoCliente() { }
        public DadosObservacaoCliente(ObservacaoClienteEntity observacaoEntity)
        {
            Observacao = observacaoEntity.Observacao;
            Id = observacaoEntity.Id;
            DataObservacao = observacaoEntity.DataObservacao;
        }
    
    }
}
