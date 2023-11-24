using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CakeUpERP.Application.Interfaces;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;

namespace CakeUpERP.Application.Service
{
    public class JwtClaimsAcessor : IClaimsAcessor
    {
        private readonly HttpContext _httpContext;
        public int IdCompanhia
        {
            get => ObterIdCompanhia();
        }

        public JwtClaimsAcessor (IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }
        private int ObterIdCompanhia()
        {
            Int32.TryParse(_httpContext.User.Claims.FirstOrDefault(c => c.Type == "IdCompanhia")?.Value, out int idCompanhia);
            return idCompanhia;
        }
    }
}
