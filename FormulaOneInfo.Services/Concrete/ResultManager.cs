using FormulaOneInfo.Data.Abstract;
using FormulaOneInfo.Entities.Concrete;
using FormulaOneInfo.Entities.Dtos.ResultDtos;
using FormulaOneInfo.Services.Abstract;
using FormulaOneInfo.Shared.Utilities.Result.ComplexTypes;
using FormulaOneInfo.Shared.Utilities.Result.Abstract;
using FormulaOneInfo.Shared.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaOneInfo.Entities.Dtos.GrandPrixDtos;
using FormulaOneInfo.Entities.Dtos.PilotDtos;

namespace FormulaOneInfo.Services.Concrete
{
    public class ResultManager : IResultService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ResultManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IResult> Add(ResultAddDto resultAddDto, string createdByName)
        {
            await _unitOfWork.Results.AddAsync(new Entities.Concrete.Result
            {
                Order = resultAddDto.Order,
                Points = resultAddDto.Points,
                GrandPrixId = resultAddDto.GrandPrixId,
                PilotId = resultAddDto.PilotId,
                TeamId = resultAddDto.TeamId,
                IsActive = resultAddDto.IsActive,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                Note = $"Kayıt eklendi"
            }).ContinueWith(t=>_unitOfWork.SaveAsync());
            return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Success, $"result is Added");
        }

        public async Task<IResult> Delete(int resultId, string modifiedByName)
        {
            var result = await _unitOfWork.Results.GetAsync(x=>x.Id == resultId);
            if(result != null)
            {
                result.IsDeleted = true;
                result.ModifiedDate = DateTime.Now;
                await _unitOfWork.Results.UpdateAsync(result).ContinueWith(t=>_unitOfWork.SaveAsync());
                return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Success, $"{result.Id} Adlı Result premio silindi");

            }
            return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Error, "Böyle bir Result premio bulunamadı", null);
        }

        public async Task<IDataResult<ResultDto>> Get(int resultId)
        {
            var result = await _unitOfWork.Results.GetAsync(x=>x.Id == resultId);
            if(result != null)
            {
                return new DataResult<ResultDto>(ResultStatus.Success, new ResultDto
                {
                   Result = result,
                   ResultStatus = ResultStatus.Success
                   
                });
            }
            return new DataResult<ResultDto>(ResultStatus.Error,"Böyle bir result kaydı yok",null);
        }

        public async Task<IDataResult<ResultListDto>> GetAll()
        {
            var results = await _unitOfWork.Results.GetAllAsync();
            if (results.Count > -1)
            {
                return new DataResult<ResultListDto>(ResultStatus.Success, new ResultListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Results = results
                });
            }
            return new DataResult<ResultListDto>(ResultStatus.Error, "Böyle bir kayıt yok", null);
        }

        public async Task<IDataResult<ResultListDto>> GetAllByNonDeleted()
        {
            var results = await _unitOfWork.Results.GetAllAsync(x => x.IsDeleted == false);
            if (results.Count > -1)
            {
                return new DataResult<ResultListDto>(ResultStatus.Success, new ResultListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Results = results
                });
            }
            return new DataResult<ResultListDto>(ResultStatus.Error, "Böyle bir result kaydı ytok", null);
        }

        public async Task<IDataResult<ResultListDto>> GetAllByNonDeletedAndActive()
        {
            var results = await _unitOfWork.Results.GetAllAsync(x => x.IsDeleted == false && x.IsActive == true);
            if (results.Count > -1)
            {
                return new DataResult<ResultListDto>(ResultStatus.Success, new ResultListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Results = results
                });
            }
            return new DataResult<ResultListDto>(ResultStatus.Error, "Böyle bir result kaydı ytok", null);
        }

        public async Task<IDataResult<ResultListDto>> GetAllBySeasonId(int seasonId)
        {
            var results = await _unitOfWork.Results.GetAllAsync(x => x.IsDeleted == false && x.IsActive == true &&x.GrandPrix.SeasonId == seasonId);
            if (results.Count > -1)
            {
                return new DataResult<ResultListDto>(ResultStatus.Success, new ResultListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Results = results
                });
            }
            return new DataResult<ResultListDto>(ResultStatus.Error, "Böyle bir result kaydı ytok", null);
        }

        public async Task<IResult> HardDelete(int resultId, string modifiedByName)
        {
            var result = await _unitOfWork.Results.GetAsync(x=>x.Id == resultId);
            if(result != null)
            {
                await _unitOfWork.Results.DeleteAsync(result).ContinueWith(t=>_unitOfWork.SaveAsync());
                return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Success, $"{result.Id} Adlı Db'den Result Premio Silinmiştir");
            }
            return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Error, $"{result.Id} Adlı Db'den Result Premio bulunamadı", null);
        }

        public async Task<IResult> Update(ResultUpdateDto resultUpdateDto, string modifiedByName)
        {
            var result = await _unitOfWork.Results.GetAsync(x=>x.Id == resultUpdateDto.ResultId);
            if(result != null )
            {
                result.Order = resultUpdateDto.Order;
                result.GrandPrixId = resultUpdateDto.GrandPrixId;
                result.PilotId = resultUpdateDto.PilotId;
                result.ModifiedDate = DateTime.Now;
                await _unitOfWork.Results.UpdateAsync(result).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Success, $"{result.Id} Adlı Result premio güncellendi");
            }
            return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Error, $"{result.Id} Adlı Result premio güncellenemedi");
        }
    }
}
