namespace Willow.Demo.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Willow.Demo.Data;

    public interface IRxJobRepository
    {
        Task<RxJob> AddAsync(RxJob rxJob);

        Task<RxJob> UpdateAsync(RxJob rxJob);

        Task<RxJob> GetAsync(Guid rxJobId);

        Task<ICollection<RxJob>> GetAllAsync();
    }


    public class RxJobRepository : IRxJobRepository
    {
        private DemoContext _context;

        public RxJobRepository(DemoContext context)
        {
            _context = context;
        }

        public async Task<RxJob> AddAsync(RxJob job)
        {
            await _context.RxJob.AddAsync(job);
            await _context.SaveChangesAsync();

            return job;
        }

        public async Task<RxJob> UpdateAsync(RxJob job)
        {
            _context.Update(job);
            await _context.SaveChangesAsync();

            return job;
        }

        public async Task<RxJob> GetAsync(Guid rxJobId)
        {
            return await _context.RxJob
                .SingleAsync(rxJob => rxJob.Id == rxJobId);
        }

        public async Task<ICollection<RxJob>> GetAllAsync()
        {
            return await _context.RxJob
                .ToListAsync();
        }
    }
}
