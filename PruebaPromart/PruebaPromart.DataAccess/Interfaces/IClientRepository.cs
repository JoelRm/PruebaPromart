
using PruebaPromart.Entities;
using PruebaPromart.Entities.Complex;

namespace PruebaPromart.DataAccess.Interfaces
{
    public interface IClientRepository
    {
        Task<List<ClientInfo?>> GetClients();
        Task<ClientInfo?> GetClientById(int id);
        Task<int> Create(Client entity);
    }
}
