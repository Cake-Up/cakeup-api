using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CakeUpERP.Controllers;
public static class ControllerExtension
{
    public static string? ObterEmailUsuario(this ControllerBase controllerBase)
    {
        var identity = controllerBase.HttpContext.User.Identity as ClaimsIdentity;
        IEnumerable<Claim> claim = identity.Claims;

        var emailUser = claim.Where(x => x.Type == ClaimTypes.Email)
                                .FirstOrDefault();

        return emailUser.Value;
    }
}
