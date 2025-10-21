using CrudJWT.DTOs;

namespace CrudJWT.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> Login(LoginRequest req);
        Task Register(RegisterRequest req);
    }
}
