using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Agile.Data;
using Agile.Data.Entities;
using Agile.Models.Box;

namespace Agile.Services.Box
{
    public class BoxService : IBoxService
    {
        private readonly ApplicationDbContext _context;
        private ApplicationDbContext DbContext;

        public BoxService(ApplicationDbContext context)
        {
            DbContext = context;
        }

        public async Task<bool> CreateBoxAsync(BoxCreate request)
        {
            var boxEntity = new BoxEntity
            {
            BoxName = request.BoxName,
            UserId = request.UserId,
            };

            DbContext.Add(boxEntity);

            var numberOfChanges = await DbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<BoxDetail> GetBoxAsync(int boxId)
        {
            var boxEntity = await DbContext.Boxes.FindAsync(boxId);

            return (boxEntity is null) ? null : new BoxDetail
            {
                Id = boxEntity.Id,
                BoxName = boxEntity.BoxName,
                UserId = boxEntity.UserId,
            };
        }
    }
}