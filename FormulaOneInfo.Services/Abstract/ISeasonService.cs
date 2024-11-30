using FormulaOneInfo.Entities.Dtos.SeasonDtos;
using FormulaOneInfo.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Services.Abstract
{
    public interface ISeasonService
    {
        Task<IDataResult<SeasonDto>> Get(int seasonId);
        Task<IDataResult<SeasonListDto>> GetAll();
        Task<IDataResult<SeasonListDto>> GetAllByNonDeleted();
        Task<IDataResult<SeasonListDto>> GetAllByNonDeletedAndActive();
        Task<IResult> Add(SeasonAddDto seasonAddDto, string createdByName);
        Task<IResult> Update(SeasonUpdateDto seasonUpdateDto, string createdByName);
        Task<IResult> Delete(int seasonId, string modifiedByName);
        Task<IResult> HardDelete(int seasonId,string modifiedByName);
    }
}
