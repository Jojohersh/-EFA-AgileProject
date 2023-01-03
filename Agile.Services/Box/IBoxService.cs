using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Models.Box;

namespace Agile.Services.Box
{
    public interface IBoxService
    {
        Task<bool> CreateBoxAsync(BoxCreate boxEntity);
        Task<BoxDetail> GetBoxAsync(int boxId);
    }
}