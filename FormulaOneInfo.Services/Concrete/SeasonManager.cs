using FormulaOneInfo.Data.Abstract;
using FormulaOneInfo.Entities.Concrete;
using FormulaOneInfo.Entities.Dtos.GrandPrixDtos;
using FormulaOneInfo.Entities.Dtos.SeasonDtos;
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
    public class SeasonManager : ISeasonService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SeasonManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IResult> Add(SeasonAddDto seasonAddDto, string createdByName)
        {
            await _unitOfWork.Seasons.AddAsync(new Season
            {
                Name = seasonAddDto.Name,
                StartedDate = seasonAddDto.StartedDate,
                EndDate = seasonAddDto.EndDate,
                IsActive = seasonAddDto.IsActive,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                Note = "Standard Seasone Premio Note"

            }).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Success, $"{seasonAddDto.Name} is Added");

        }


        public async Task<IResult> Delete(int seasonId, string modifiedByName)
        {
            var season = await _unitOfWork.Seasons.GetAsync(x=>x.Id == seasonId);
            if(season != null)
            {
                season.IsDeleted = true;
                await _unitOfWork.Seasons.UpdateAsync(season).ContinueWith(t=>_unitOfWork.SaveAsync());
                return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Success, $"{season.Name} Adlı Seasone premio silindi");
            }
            return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Error, "Böyle bir seasone premio bulunamadı", null);
        }

        public async Task<IDataResult<SeasonDto>> Get(int seasonId)
        {
            var season = await _unitOfWork.Seasons.GetAsync(x=>x.Id == seasonId,x=>x.GrandPrixes);
            if (season != null)
            {
                return new DataResult<SeasonDto>(ResultStatus.Success, new SeasonDto
                {
                    ResultStatus = ResultStatus.Success,
                    Season = season,
                });
            }
            return new DataResult<SeasonDto>(ResultStatus.Error,"Böyle bir season kaydı bulunamadı",null);
        }

        public async Task<IDataResult<SeasonListDto>> GetAll()
        {
            var seasons = await _unitOfWork.Seasons.GetAllAsync(null,x=>x.GrandPrixes);
            if(seasons.Count() > -1)
            {
                return new DataResult<SeasonListDto>(ResultStatus.Success, new SeasonListDto
                {
                    Seasons = seasons,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<SeasonListDto>(ResultStatus.Error, "Böyle bir sezon listesi bulunamadı", null);
        }

        public async Task<IDataResult<SeasonListDto>> GetAllByNonDeleted()
        {
            var seasons = await _unitOfWork.Seasons.GetAllAsync(x=>x.IsDeleted == false, x => x.GrandPrixes);
            if (seasons.Count() > -1)
            {
                return new DataResult<SeasonListDto>(ResultStatus.Success, new SeasonListDto
                {
                    Seasons = seasons,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<SeasonListDto>(ResultStatus.Error, "Böyle bir sezon listesi bulunamadı", null);
        }

        public async Task<IDataResult<SeasonListDto>> GetAllByNonDeletedAndActive()
        {
            var seasons = await _unitOfWork.Seasons.GetAllAsync(x => x.IsDeleted == false && x.IsActive ==true, x => x.GrandPrixes);
            if (seasons.Count() > -1)
            {
                return new DataResult<SeasonListDto>(ResultStatus.Success, new SeasonListDto
                {
                    Seasons = seasons,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<SeasonListDto>(ResultStatus.Error, "Böyle bir sezon listesi bulunamadı", null);
        }

        public async Task<IResult> HardDelete(int seasonId, string modifiedByName)
        {
            var season = await _unitOfWork.Seasons.GetAsync(x => x.Id == seasonId);
            if(season != null)
            {
                await _unitOfWork.Seasons.DeleteAsync(season).ContinueWith(t=>_unitOfWork.SaveAsync());
                return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Success, $"{season.Name} Adlı Db'den seasone Premio Silinmiştir");
            }
            return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Error, $"{season.Name} Adlı Db'den seasone Premio bulunamadı", null);
        }

        public async Task<IResult> Update(SeasonUpdateDto seasonUpdateDto, string createdByName)
        {
            var season = await _unitOfWork.Seasons.GetAsync(x=>x.Id == seasonUpdateDto.Id);
            if (season != null) 
            {
                season.Name = seasonUpdateDto.Name;
                season.StartedDate = seasonUpdateDto.StartedDate;
                season.EndDate = seasonUpdateDto.EndDate;
                season.IsActive = seasonUpdateDto.IsActive;
                await _unitOfWork.Seasons.UpdateAsync(season).ContinueWith(t=> _unitOfWork.SaveAsync());
                return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Success, $"{seasonUpdateDto.Name} Adlı Seasone premio güncellendi");
            }
            return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Error, "Böyle bir Grande premio bulunamadı", null);
        }
    }
}
