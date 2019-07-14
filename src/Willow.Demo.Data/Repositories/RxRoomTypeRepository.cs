namespace Willow.Demo.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Willow.Demo.Data;

    public interface IRxRoomTypeRepository
    {
        Task<RxRoomType> AddAsync(RxRoomType rxRoomType);

        Task<RxRoomType> GetAsync(Guid roomTypeId);

        Task<ICollection<RxRoomType>> GetAllAsync();
    }


    public class RxRoomTypeRepository : IRxRoomTypeRepository
    {
        private DemoContext _context;

        public RxRoomTypeRepository(DemoContext context)
        {
            _context = context;
        }

        public async Task<RxRoomType> AddAsync(RxRoomType rxRoomType)
        {
            await _context.RxRoomType.AddAsync(rxRoomType);
            await _context.SaveChangesAsync();

            return rxRoomType;
        }

        public async Task<RxRoomType> GetAsync(Guid rxRoomTypeId)
        {
            return await _context.RxRoomType
                .SingleAsync(rxRoomType => rxRoomType.Id == rxRoomTypeId);
        }

        public async Task<ICollection<RxRoomType>> GetAllAsync()
        {
            return await _context.RxRoomType
                .ToListAsync();
        }
    }
}
