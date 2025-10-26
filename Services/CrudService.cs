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
            return allClients.Select(x => new ClientResponse(x.Id, x.FirstName, x.LastName, x.Age, x.PhoneNumber));
        }

        public async Task<ClientRequest> GetById(Guid id)
        {
            var findClient = await context.Clients.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (findClient is null)
                throw new InvalidDataException("Nenhum cliente encontrado para o ID informado.");

            return new ClientRequest { firstName = findClient.FirstName, lastName = findClient.LastName, age = findClient.Age, phoneNumber = findClient.PhoneNumber };
        }

        public async Task<Guid> Insert(ClientRequest req)
        {
            var findClient = await context.Clients.FirstOrDefaultAsync(x => x.FirstName.Equals(req.firstName) && x.LastName.Equals(req.lastName));

            if (findClient is not null)
                throw new InvalidDataException("Já existe um cliente com este nome cadastrado.");

            var client = new ClientModel(req);
            context.Clients.Add(client);
            await context.SaveChangesAsync();
            return client.Id;
        }
    }
}
