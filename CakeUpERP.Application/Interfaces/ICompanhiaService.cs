﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Application.Interfaces
{
    public interface ICompanhiaService
    {
        public bool VerificarCnpjCadastrado(string cnpj);
    }
}
