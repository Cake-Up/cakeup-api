using Microsoft.AspNetCore.Mvc;

namespace CakeUpERP.WebApi.Controllers
{
    public class CompanhiaController : Controller
    {
        [HttpGet("VerificarCnpj/{cnpj}")]
        public IActionResult VerificarCnpjCadastrado(string cnpj)
        {
            try
            {
                if (Maoli.Cnpj.Validate(cnpj)) 
                    throw new Exception("Cnpj Invalido!");
                
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
