﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Domain.Entities
{
    public class ItemOrcamentoEntity : EntityBase
    {
        public ReceitaEntity Receita { get; set; }
    }
}
