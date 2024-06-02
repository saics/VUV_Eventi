using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PIS.DAL.DataModel;
using PIS.Model;
using PIS.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Repository
{
    public class EventiRepository : IEventiRepository
    {
        private readonly PIS_DbContext2 _context;
        private readonly IMapper _mapper;

        public EventiRepository(PIS_DbContext2 context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventiDomain>> GetAllEventiAsync()
        {
            var eventi = await _context.Eventi.ToListAsync();
            return _mapper.Map<IEnumerable<EventiDomain>>(eventi);
        }

        public async Task<EventiDomain> GetEventiByIdAsync(int id)
        {
            var eventi = await _context.Eventi.FindAsync(id);
            return _mapper.Map<EventiDomain>(eventi);
        }

        public async Task<EventiDomain> AddEventiAsync(EventiDomain eventi)
        {
            var entity = _mapper.Map<Eventi>(eventi);
            _context.Eventi.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<EventiDomain>(entity);
        }

        public async Task UpdateEventiAsync(EventiDomain eventi)
        {
            var entity = await _context.Eventi.FindAsync(eventi.Id);
            if (entity != null)
            {
                _mapper.Map(eventi, entity);
                _context.Eventi.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteEventiAsync(int id)
        {
            var entity = await _context.Eventi.FindAsync(id);
            if (entity != null)
            {
                _context.Eventi.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }

}
