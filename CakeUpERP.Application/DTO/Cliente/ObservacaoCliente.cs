using CakeUpERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Application.DTO.Cliente
{
    public class ObservacaoClienteDTO
    {
        public int Id { get; set; }
        public DateTime DataObservacao { get; set; }
        public string Observacao { get; set; }
    
        public ObservacaoClienteDTO() { }
        public ObservacaoClienteDTO(ObservacaoClienteEntity observacaoEntity)
        {
            Observacao = observacaoEntity.Observacao;
            Id = observacaoEntity.Id;
            DataObservacao = observacaoEntity.DataObservacao;
        }
    
    }
}
