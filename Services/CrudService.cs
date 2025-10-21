using CrudJWT.Context;
using CrudJWT.DTOs;
using CrudJWT.Interfaces;
using CrudJWT.Model;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace CrudJWT.Services
{
    public class CrudService : ICrudService
    {
        private readonly CrudContext context;

        public CrudService(CrudContext _context)
        {
            context = _context;    
        }

        public async Task<bool> Delete(Guid id)
        {
            var findClient = await context.Clients.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (findClient is null)
                throw new InvalidDataException("Nenhum cliente encontrado para o ID informado.");

            context.Clients.Remove(findClient);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ClientResponse>> GetAll()
        {
            var allClients = await context.Clients.ToListAsync();
            return allClients.Select(x => new ClientResponse(x.Id, x.firstName, x.lastName, x.age, x.phoneNumber));
        }

        public async Task<ClientRequest> GetById(Guid id)
        {
            var findClient = await context.Clients.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (findClient is null)
                throw new InvalidDataException("Nenhum cliente encontrado para o ID informado.");

            return new ClientRequest(findClient.firstName, findClient.lastName, findClient.age, findClient.phoneNumber);
        }

        public async Task<Guid> Insert(ClientRequest req)
        {
            if (string.IsNullOrEmpty(req.firstName) || req.firstName.Length <= 3)
                throw new ArgumentException("O nome do cliente precisa ser definido.");

            if (string.IsNullOrEmpty(req.lastName) || req.lastName.Length <= 3)
                throw new ArgumentException("O sobrenome do cliente precisa ser definido.");

            if (string.IsNullOrEmpty(req.phoneNumber) || req.phoneNumber.Length != 11)
                throw new ArgumentException("O número de celular informado é inválido. [válido: DD+numero]");

            if (req.age < 18 || req.age > 120)
                throw new ArgumentException("A idade informada é inválida.");

            var findClient = await context.Clients.FirstOrDefaultAsync(x => x.firstName.Equals(req.firstName) && x.lastName.Equals(req.lastName));

            if (findClient is not null)
                throw new InvalidDataException("Já existe um cliente com este nome cadastrado.");

            var client = new ClientModel(req);
            context.Clients.Add(client);
            await context.SaveChangesAsync();
            return client.Id;
        }
    }
}
