using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PIS.DAL.DataModel;
using PIS.Model;
using PIS.Repository.Common;

namespace PIS.Repository
{
    public class UlogeRepository : IUlogeRepository
    {
        private readonly PIS_DbContext2 _context;
        private readonly IMapper _mapper;

        public UlogeRepository(PIS_DbContext2 context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UlogeDomain>> GetAllUlogeAsync()
        {
            var uloge = await _context.Uloge.ToListAsync();
            return _mapper.Map<IEnumerable<UlogeDomain>>(uloge);
        }

        public async Task<UlogeDomain> GetUlogeByIdAsync(int id)
        {
            var uloge = await _context.Uloge.FindAsync(id);
            return _mapper.Map<UlogeDomain>(uloge);
        }

        public async Task<UlogeDomain> AddUlogeAsync(UlogeDomain uloge)
        {
            var entity = _mapper.Map<Uloge>(uloge);
            _context.Uloge.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<UlogeDomain>(entity);
        }

        public async Task UpdateUlogeAsync(UlogeDomain uloge)
        {
            var entity = await _context.Uloge.FindAsync(uloge.Id);
            if (entity != null)
            {
                _mapper.Map(uloge, entity);
                _context.Uloge.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUlogeAsync(int id)
        {
            var entity = await _context.Uloge.FindAsync(id);
            if (entity != null)
            {
                _context.Uloge.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
