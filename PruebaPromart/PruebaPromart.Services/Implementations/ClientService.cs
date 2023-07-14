using AutoMapper;
using PruebaPromart.DataAccess.Interfaces;
using PruebaPromart.DTO.Request;
using PruebaPromart.DTO.Response;
using PruebaPromart.Entities;
using PruebaPromart.Entities.Complex;
using PruebaPromart.Services.Interfaces;

namespace PruebaPromart.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository repository, IMapper mapper)
        {
            _repository = repository;  
            _mapper = mapper;   
        }

        public async Task<BaseResponseEntity<List<ClientInfo?>>> GetClients()
        {
            var response = new BaseResponseEntity<List<ClientInfo?>>();
            try
            {
                var client = await _repository.GetClients();
                if (client != null)
                {
                    
                    for (int i = 0; i < client.Count; i++)
                    {
                        client[i].BirthDate = DateTime.Parse(client[i].BirthDate).ToShortDateString();
                        client[i].Age = CalculateAge(DateTime.Parse(client[i].BirthDate));
                    }
                }
                response.ResponseResult = client;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponseEntity<ClientInfo?>> GetClientById(int id)
        {
            var response = new BaseResponseEntity<ClientInfo?>();
            try
            {
                var client = await _repository.GetClientById(id);
                if (client != null)
                {
                    client.BirthDate = DateTime.Parse(client.BirthDate).ToShortDateString();
                    client.Age = CalculateAge(DateTime.Parse(client.BirthDate));
                }
                response.ResponseResult = client;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseEntity<List<ClientInfo?>>> GetOlderClients()
        {
            var response = new BaseResponseEntity<List<ClientInfo?>>();
            try
            {
                var client = await _repository.GetClients();
                if (client != null)
                {
                    for (int i = 0; i < client.Count; i++)
                    {
                        client[i].BirthDate = DateTime.Parse(client[i].BirthDate).ToShortDateString();
                        client[i].Age = CalculateAge(DateTime.Parse(client[i].BirthDate));
                    }
                    var groupClient = (from c in client
                                      group c by c.Age into cGroup
                                      orderby cGroup.Key descending
                                      select cGroup).ToList();

                    client = groupClient.SelectMany(group => group).Take(3).ToList();
                }
                response.ResponseResult = client;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponseEntity<int>> Create(DtoClient request)
        {
            var response = new BaseResponseEntity<int>();
            try
            {
                Client entity = _mapper.Map<Client>(request);

                response.ResponseResult = await _repository.Create(entity);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }

        private int CalculateAge(DateTime date)
        {
            int anio = DateTime.Now.Year;
            int mes = DateTime.Now.Month;
            int resta = 0;
            int edad = 0;

            if (date.Month > mes) resta = 1;

            edad = (anio - date.Year) - resta;

            return edad;
        }

    }
}
