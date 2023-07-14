
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PruebaPromart.DataAccess.Interfaces;
using PruebaPromart.Entities;
using PruebaPromart.Entities.Complex;

namespace PruebaPromart.DataAccess.Implementations
{
    public class ClientRepository : IClientRepository
    {
        private readonly PruebaPromartDbContext _context;
        private readonly IMapper _mapper;

        public ClientRepository(PruebaPromartDbContext context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
        }

        public async Task<List<ClientInfo?>> GetClients()
        {
            return await _context.Set<Client>()
                                  .Select(c => _mapper.Map<ClientInfo?>(c))
                                  .ToListAsync();
        }

        public async Task<ClientInfo?> GetClientById(int id)
        {
            return await _context.Set<Client>()
                                 .Where(c => c.Id == id)
                                 .Select(c => _mapper.Map<ClientInfo?>(c))
                                 .SingleOrDefaultAsync();
        }

        public async Task<int> Create(Client entity)
        {
            await _context.Set<Client>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }
    }
}
