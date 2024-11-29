using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Data.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IGrandPrixRepository GrandPrixes { get; }
        IPilotRepository Pilots { get; }
        IResultRepository Results { get; }
        ISeasonRepository Seasons { get; }
        ITeamRepository Teams { get; }
        Task<int> SaveAsync();

    }
}
