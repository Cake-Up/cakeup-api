using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Application.DTO.Bases
{
    public class DefaultResponse
    {
        public string Mensagem { get; set; }
        private DefaultResponse(string msg)
        {
            Mensagem = msg;
        }

        public static DefaultResponse Response(string msg)
        {
            return new DefaultResponse(msg);
        }
    }
}
