﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Domain.Entities
{
    public class UtensiliosEEquipamentosEntity : EntityBase
    {
        public string Nome { get; set; }
        public decimal CustoCompra { get; set; }
        public DateTime DataCompra { get; set; }
        public int TipoUtensilio { get; set; }

        public int IdReceita { get; set; }
        public virtual ReceitaEntity Receita { get; set; }
        public virtual ICollection<RlUtensiliosReceita> ReceitasUtensilios { get; set; }
    }
}
