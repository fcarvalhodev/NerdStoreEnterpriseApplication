using NSE.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public interface IAuthenticationService
    {
        Task<UserResponseLogin> Login(UserLogin userLogin);

        Task<UserResponseLogin> Register(UserRegister userRegister);
    }


}
