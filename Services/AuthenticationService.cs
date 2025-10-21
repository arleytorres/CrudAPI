using CrudJWT.Context;
using CrudJWT.DTOs;
using CrudJWT.Interfaces;
using CrudJWT.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CrudJWT.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration config;
        private readonly CrudContext context;
        public AuthenticationService(IConfiguration _config, CrudContext _context)
        {
            config = _config;
            context = _context;
        }

        public async Task<string> Login(LoginRequest req)
        {
            string username = req.username.Trim();
            string password = req.password.Trim();

            if (string.IsNullOrEmpty(username) || username.Length <= 3)
                throw new ArgumentException("O username precisa ser definido.");

            if (string.IsNullOrEmpty(password) || password.Length <= 3)
                throw new ArgumentException("A senha precisa ser definido.");

            var findLogin = await context.Logins.FirstOrDefaultAsync(x => x.username.Equals(username));

            if (findLogin is null)
                throw new InvalidOperationException("O username informado não existe.");

            if (!BCrypt.Net.BCrypt.Verify(password, findLogin.password))
                throw new UnauthorizedAccessException("A senha é inválida.");

            string token = await GetToken(username, findLogin.role);

            return token;
        }

        public async Task Register(RegisterRequest req)
        {
            string username = req.username.Trim();
            string password = req.password.Trim();
            string password2 = req.confirm_password.Trim();
            string role = req.role.Trim();

            if (string.IsNullOrEmpty(username) || username.Length <= 3)
                throw new ArgumentException("O username precisa ser definido.");

            if (string.IsNullOrEmpty(password) || password.Length <= 3)
                throw new ArgumentException("A senha precisa ser definido.");

            if (string.IsNullOrEmpty(role) || role.Length <= 3)
                throw new ArgumentException("A role precisa ser definido.");

            if (!password.Equals(password2))
                throw new ArgumentException("As senhas não são equivalentes.");

            var findLogin = await context.Logins.FirstOrDefaultAsync(x => x.username.Equals(username));

            if (findLogin is not null)
                throw new InvalidOperationException("Já existe uma conta com este username.");

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            var login = new LoginModel(username, hashedPassword, role);
            context.Logins.Add(login);
            await context.SaveChangesAsync();
        }

        private Task<string> GetToken(string username, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            string? jwtKey = config["Jwt:Key"];

            if (jwtKey is null)
                return null;

            byte[] key = Encoding.ASCII.GetBytes(jwtKey);

            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptior);
            var jwt = tokenHandler.WriteToken(token);
            return Task.FromResult(jwt);
        }
    }
}
