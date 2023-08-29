﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Domain.Entities
{
    public class AtualizacoesPrecosEntity: EntityBase
    {
        public DateTime DataAtualizacao { get; set; }
        public int IdReceita { get; set; }
        public int IdIngrediente { get; set; }
        public int QtdProduto { get; set; }
        public int Preco { get; set; }
        public IngredienteEntity Ingrediente { get; set; }
        public ReceitaEntity Receita { get; set; }
    }
}
