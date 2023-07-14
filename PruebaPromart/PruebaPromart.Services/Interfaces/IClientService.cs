using PruebaPromart.DTO.Request;
using PruebaPromart.DTO.Response;
using PruebaPromart.Entities.Complex;

namespace PruebaPromart.Services.Interfaces
{
    public interface IClientService
    {
        Task<BaseResponseEntity<List<ClientInfo?>>> GetClients();
        Task<BaseResponseEntity<ClientInfo?>> GetClientById(int id);
        Task<BaseResponseEntity<List<ClientInfo?>>> GetOlderClients();
        Task<BaseResponseEntity<int>> Create(DtoClient request);
    }
}
