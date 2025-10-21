
using CrudJWT.Context;
using CrudJWT.DTOs;
using CrudJWT.Interfaces;
using CrudJWT.Services;
using Microsoft.AspNetCore.Authorization;

namespace CrudJWT.Routes
{
    public static class AppRoutes
    {
        public static void ClientRoutes(this WebApplication app)
        {
            var route = app.MapGroup("api/v1/auth").WithTags("Auth");

            route.MapPost("login", async (LoginRequest req, IConfiguration config, IAuthenticationService service) =>
            {
                string result = await service.Login(req);
                return Results.Ok(new { Status = "Success", Token = result });
            });

            route.MapPost("register", async (RegisterRequest req, IConfiguration config, IAuthenticationService service) =>
            {
                await service.Register(req);
                return Results.Ok(new { Status = "Success" });
            });
        }

        public static void CrudRoutes(this WebApplication app)
        {
            var route = app.MapGroup("api/v1/clients").RequireAuthorization().WithTags("Clients");

            route.MapPost("insert", async (ClientRequest req, ICrudService service) =>
            {
                var id = await service.Insert(req);
                return Results.Ok(new { Result = "Cliente cadastrado com sucesso!", ClientId = id });
            });

            route.MapDelete("delete/{Id:Guid}", async (Guid Id, ICrudService service) =>
            {
                var all = await service.Delete(Id);
                return Results.Ok(all ? "Cliente removido com sucesso!" : "Não foi possível remover este cliente");
            });

            route.MapGet("getbyid/{Id:Guid}", async (Guid Id, ICrudService service) =>
            {
                var Client = await service.GetById(Id);
                return Results.Ok(Client);
            });

            route.MapGet("getall", async (ICrudService service) =>
            {
                var all = await service.GetAll();
                return Results.Ok(all);
            });
        }
    }
}
