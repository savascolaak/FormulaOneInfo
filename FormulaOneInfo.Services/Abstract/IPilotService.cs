using FormulaOneInfo.Entities.Concrete;
using FormulaOneInfo.Entities.Dtos.PilotDtos;
using FormulaOneInfo.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Services.Abstract
{
    public interface IPilotService
    {
        Task<IDataResult<PilotDto>> Get(int pilotId);
        Task<IDataResult<PilotListDto>> GetAll();        
        Task<IDataResult<PilotListDto>> GetAllByNonDeleted();
        Task<IDataResult<PilotListDto>> GetAllByNonDeletedAndActive();
        Task<IResult> Add(PilotAddDto pilotAddDto);
        Task<IResult> Update(PilotUpdateDto pilotUpdateDto);
        Task<IResult> Delete(int pilotId);
        Task<IResult> HardDelete(int pilotId);
    }
}
