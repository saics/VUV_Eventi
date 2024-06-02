using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PIS.DAL.DataModel;
using PIS.Model;
using PIS.Repository.Common;

namespace PIS.Repository
{
    public class StatusRepository : IStatusRepository
    {
        private readonly PIS_DbContext2 _context;
        private readonly IMapper _mapper;

        public StatusRepository(PIS_DbContext2 context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StatusDomain>> GetAllStatusAsync()
        {
            var statuses = await _context.Status.ToListAsync();
            return _mapper.Map<IEnumerable<StatusDomain>>(statuses);
        }

        public async Task<StatusDomain> GetStatusByIdAsync(int id)
        {
            var status = await _context.Status.FindAsync(id);
            return _mapper.Map<StatusDomain>(status);
        }

        public async Task<StatusDomain> AddStatusAsync(StatusDomain status)
        {
            var entity = _mapper.Map<Status>(status);
            _context.Status.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<StatusDomain>(entity);
        }

        public async Task UpdateStatusAsync(StatusDomain status)
        {
            var entity = await _context.Status.FindAsync(status.Id);
            if (entity != null)
            {
                _mapper.Map(status, entity);
                _context.Status.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteStatusAsync(int id)
        {
            var entity = await _context.Status.FindAsync(id);
            if (entity != null)
            {
                _context.Status.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
