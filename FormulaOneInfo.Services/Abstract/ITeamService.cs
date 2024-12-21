using FormulaOneInfo.Entities.Dtos.TeamDtos;
using FormulaOneInfo.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Services.Abstract
{
    public interface ITeamService
    {
        Task<IDataResult<TeamDto>> Get(int teamId);
        Task<IDataResult<TeamListDto>> GetAll();
        Task<IDataResult<TeamListDto>> GetAllByNonDeleted();
        Task<IDataResult<TeamListDto>> GetAllByNonDeletedAndActive();
        Task<IResult> Add(TeamAddDto teamAddDto);
        Task<IResult> Update(TeamUpdateDto teamUpdateDto);
        Task<IResult> Delete(int teamId);
        Task<IResult> HardDelete(int teamId);


    }
}
