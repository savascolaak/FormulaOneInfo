using FormulaOneInfo.Entities.Concrete;
using FormulaOneInfo.Entities.Dtos.ResultDtos;
using FormulaOneInfo.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Services.Abstract
{
    public interface IResultService
    {
        Task<IDataResult<ResultDto>> Get(int resultId);
        Task<IDataResult<ResultListDto>> GetAll();
        Task<IDataResult<ResultListDto>> GetAllBySeasonId(int seasonId);
        Task<IDataResult<ResultListDto>> GetAllByNonDeleted();
        Task<IDataResult<ResultListDto>> GetAllByNonDeletedAndActive();
        Task<IResult> Add(ResultAddDto resultAddDto, string createdByName);
        Task<IResult> Update(ResultUpdateDto resultUpdateDto, string modifiedByName);
        Task<IResult> Delete(int resultId,string modifiedByName);
        Task<IResult> HardDelete(int resultId,string modifiedByName);
    }
}
