using FormulaOneInfo.Data.Abstract;
using FormulaOneInfo.Entities.Concrete;
using FormulaOneInfo.Entities.Dtos.GrandPrixDtos;
using FormulaOneInfo.Services.Abstract;
using FormulaOneInfo.Shared.Utilities.Result.Abstract;
using FormulaOneInfo.Shared.Utilities.Result.ComplexTypes;
using FormulaOneInfo.Shared.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Services.Concrete
{
    public class GrandPrixManager : IGrandPrixService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GrandPrixManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IResult> Add(GrandPrixAddDto grandPrixAddDto, string createdByName)
        {
            await _unitOfWork.GrandPrixes.AddAsync(new GrandPrix
            {
                Name = grandPrixAddDto.Name,
                Track = grandPrixAddDto.Track,
                Country = grandPrixAddDto.Country,
                City = grandPrixAddDto.City,
                GrandPrixDate = grandPrixAddDto.GrandPrixDate,
                SeasonId = grandPrixAddDto.SeasonId,
                IsActive = grandPrixAddDto.IsActive,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                Note = "Standard Grande Premio Note"

            }).ContinueWith(t=>_unitOfWork.SaveAsync());
            return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Success,$"{grandPrixAddDto.Name} is Added");
        }

        public async Task<IResult> Delete(int grandPrixId, string modifiedByName)
        {
            var grandPrix = await _unitOfWork.GrandPrixes.GetAsync(x=>x.Id == grandPrixId);
            if(grandPrix != null)
            {
                grandPrix.IsDeleted = true;
                grandPrix.ModifiedDate = DateTime.Now;
                await _unitOfWork.GrandPrixes.UpdateAsync(grandPrix).ContinueWith(t=>_unitOfWork.SaveAsync());
                return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Success, $"{grandPrix.Name} Adlı Grande premio silindi");
            }
            return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Error, "Böyle bir Grande premio bulunamadı", null);
        }

        public async Task<IDataResult<GrandPrixDto>> Get(int GrandPrixId)
        {
            var grandPrix = await _unitOfWork.GrandPrixes.GetAsync(x => x.Id == GrandPrixId,x=>x.Results);
            if(grandPrix != null)
            {
                return new DataResult<GrandPrixDto>(ResultStatus.Success, new GrandPrixDto
                {
                    GrandPrix = grandPrix,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<GrandPrixDto>(ResultStatus.Error,"Böyle bir Grand Prix Bulunamadı",null);
        }

        public async Task<IDataResult<GrandPrixListDto>> GetAll()
        {
            var grandPrixes = await _unitOfWork.GrandPrixes.GetAllAsync(null,c=>c.Results);
            if (grandPrixes.Count >= -1)
            {
                return new DataResult<GrandPrixListDto>(ResultStatus.Success, new GrandPrixListDto
                {
                    GrandPrixes = grandPrixes,
                    ResultStatus = ResultStatus.Success
                    
                });
            }
            return new DataResult<GrandPrixListDto>(ResultStatus.Error, "Böyle bir kayıt bulunamadı", null);
        }

        public async Task<IDataResult<GrandPrixListDto>> GetAllByNonDeleted()
        {
            var grandPrixes = await _unitOfWork.GrandPrixes.GetAllAsync(x=>x.IsDeleted == false, c => c.Results);
            if (grandPrixes.Count >= -1)
            {
                return new DataResult<GrandPrixListDto>(ResultStatus.Success, new GrandPrixListDto
                {
                    GrandPrixes = grandPrixes,
                    ResultStatus = ResultStatus.Success

                });
            }
            return new DataResult<GrandPrixListDto>(ResultStatus.Error, "Böyle bir kayıt bulunamadı", null);
        }

        public async Task<IDataResult<GrandPrixListDto>> GetAllByNonDeletedAndActive()
        {
            var grandPrixes = await _unitOfWork.GrandPrixes.GetAllAsync(x => x.IsDeleted == false &&x.IsActive==true , c => c.Results);
            if (grandPrixes.Count >= -1)
            {
                return new DataResult<GrandPrixListDto>(ResultStatus.Success, new GrandPrixListDto
                {
                    GrandPrixes = grandPrixes,
                    ResultStatus = ResultStatus.Success

                });
            }
            return new DataResult<GrandPrixListDto>(ResultStatus.Error, "Böyle bir kayıt bulunamadı", null);
        }

        public async Task<IResult> HardDelete(int grandPrixId, string modifiedByName)
        {
            var grandPrix = await _unitOfWork.GrandPrixes.GetAsync(x=>x.Id == grandPrixId);
            if(grandPrix != null)
            {
                await _unitOfWork.GrandPrixes.DeleteAsync(grandPrix).ContinueWith(x =>_unitOfWork.SaveAsync());
                return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Success, $"{grandPrix.Name} Adlı Db'den Grande Premio Silinmiştir");
            }
            return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Error, $"{grandPrix.Name} Adlı Db'den Grande Premio bulunamadı",null);
        }

        public async Task<IResult> Update(GrandPrixUpdateDto grandPrixUpdateDto, string modifiedByName)
        {
            var grandPrix = await _unitOfWork.GrandPrixes.GetAsync(x => x.Id == grandPrixUpdateDto.Id);
            if(grandPrix != null)
            {
                grandPrix.Name = grandPrixUpdateDto.Name;
                grandPrix.Track = grandPrixUpdateDto.Track;
                grandPrix.Country = grandPrixUpdateDto.Country;
                grandPrix.City = grandPrixUpdateDto.City;
                grandPrix.GrandPrixDate = grandPrixUpdateDto.GrandPrixDate;                
                grandPrix.IsActive = grandPrixUpdateDto.IsActive;
                grandPrix.ModifiedDate = DateTime.Now;
                await _unitOfWork.GrandPrixes.UpdateAsync(grandPrix).ContinueWith(t=>_unitOfWork.SaveAsync());
                return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Success, $"{grandPrixUpdateDto.Name} Adlı Grande premio güncellendi");
            }
            return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Error, "Böyle bir Grande premio bulunamadı", null);
        }
    }
}
