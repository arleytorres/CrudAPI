using CrudJWT.DTOs;
using CrudJWT.Model;

namespace CrudJWT.Interfaces
{
    public interface ICrudService
    {
        Task<Guid> Insert(ClientRequest req);
        Task<bool> Delete(Guid id);
        Task<ClientRequest> GetById(Guid id);
        Task<List<ClientModel>> GetAll();
    }
}
