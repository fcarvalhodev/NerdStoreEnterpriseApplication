using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace NSE.WebApp.MVC.Controllers
{
    public class MainController : Controller
    {
        #region .: Error :.

        protected bool ReponseHasErrors(ResponseResult result)
        {
            if (result != null && result.Errors.Messages.Any())
            {

                foreach (var message in result.Errors.Messages)
                {
                    ModelState.AddModelError(string.Empty, message);
                }

                return true;
            }

            return false;
        }

        #endregion

        #region .: Token :.

        protected JwtSecurityToken GetTokenFormat(string jwtToken)
        {
            return new JwtSecurityTokenHandler().ReadToken(jwtToken) as JwtSecurityToken;
        }

        #endregion
    }
}
