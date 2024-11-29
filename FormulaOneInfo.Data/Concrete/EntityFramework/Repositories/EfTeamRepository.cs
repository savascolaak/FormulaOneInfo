using FormulaOneInfo.Data.Abstract;
using FormulaOneInfo.Entities.Concrete;
using FormulaOneInfo.Shared.Data.Abstract;
using FormulaOneInfo.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Data.Concrete.EntityFramework.Repositories
{
    public class EfTeamRepository : EfEntityRepositoryBase<Team>, ITeamRepository
    {
        public EfTeamRepository(DbContext context) : base(context)
        {
        }
    }
}
