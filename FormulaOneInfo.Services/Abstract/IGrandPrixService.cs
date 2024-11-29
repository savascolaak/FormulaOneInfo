using FormulaOneInfo.Entities.Dtos.GrandPrixDtos;
using FormulaOneInfo.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Services.Abstract
{
    public interface IGrandPrixService
    {
        Task<IDataResult<GrandPrixDto>> Get(int GrandPrixId);
        Task<IDataResult<GrandPrixListDto>> GetAll();
        Task<IDataResult<GrandPrixListDto>> GetAllByNonDeleted();
        Task<IDataResult<GrandPrixListDto>> GetAllByNonDeletedAndActive();
        Task<IResult> Add(GrandPrixAddDto grandPrixAddDto, string createdByName);
        Task<IResult> Update(GrandPrixUpdateDto grandPrixUpdateDto, string modifiedByName);
        Task<IResult> Delete(int grandPrixId,string modifiedByName);
        Task<IResult> HardDelete(int grandPrixId, string modifiedByName);

    }
}
