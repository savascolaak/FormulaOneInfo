using FormulaOneInfo.Data.Abstract;
using FormulaOneInfo.Data.Concrete.EntityFramework.Contexts;
using FormulaOneInfo.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Data.Concrete.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FormulaOneContext _context;
        private EfGrandPrixRepository _grandPrixRepository;
        private EfPilotRepository _pilotRepository;
        private EfResultRepository _resultRepository;
        private EfSeasonRepository _seasonRepository;
        private EfTeamRepository _teamRepository;

        public UnitOfWork(FormulaOneContext context)
        {
           _context = context;
        }
        public IGrandPrixRepository GrandPrixes => _grandPrixRepository ?? new EfGrandPrixRepository(_context);

        public IPilotRepository Pilots => _pilotRepository ?? new EfPilotRepository(_context);

        public IResultRepository Results => _resultRepository ?? new EfResultRepository(_context);

        public ISeasonRepository Seasons => _seasonRepository ?? new EfSeasonRepository(_context);

        public ITeamRepository Teams => _teamRepository ?? new EfTeamRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
         return await  _context.SaveChangesAsync();
        }
    }
}
