using FormulaOneInfo.Data.Abstract;
using FormulaOneInfo.Entities.Concrete;
using FormulaOneInfo.Entities.Dtos.PilotDtos;
using FormulaOneInfo.Services.Abstract;
using FormulaOneInfo.Shared.Utilities.Result.Abstract;
using FormulaOneInfo.Shared.Utilities.Result.ComplexTypes;
using FormulaOneInfo.Shared.Utilities.Result.Concrete;


namespace FormulaOneInfo.Services.Concrete
{
    public class PilotManager : IPilotService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PilotManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IResult> Add(PilotAddDto pilotAddDto)
        {
            await _unitOfWork.Pilots.AddAsync(new Pilot
            {
                FirstName = pilotAddDto.FirstName,
                LastName = pilotAddDto.LastName,
                Thumbnail = pilotAddDto.Thumbnail,
                DateOfBirth = pilotAddDto.DateOfBirth,
                Nationality = pilotAddDto.Nationality,
                IsActive = pilotAddDto.IsActive,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                Note = $"{pilotAddDto.FirstName} + {pilotAddDto.LastName} adlı pilot kaydı eklenmiştir."
            }).ContinueWith(x => _unitOfWork.SaveAsync());
            return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Success, $"{pilotAddDto.FirstName} is Added");
        }

        public async Task<IResult> Delete(int pilotId)
        {
            var pilot = await _unitOfWork.Pilots.GetAsync(x => x.Id == pilotId);
            if (pilot != null)
            {
                pilot.IsDeleted = true;
                await _unitOfWork.Pilots.UpdateAsync(pilot).ContinueWith(x => _unitOfWork.SaveAsync());
                return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Success, $"{pilot.FirstName} adlı kayıt silindi");
            }
            return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Error, $"{pilot.FirstName} adlı kayıt bulunamadı");
        }

        public async Task<IDataResult<PilotDto>> Get(int pilotId)
        {
            var pilot = await _unitOfWork.Pilots.GetAsync(x => x.Id == pilotId, x => x.Results);
            if (pilot != null)
            {
                return new DataResult<PilotDto>(ResultStatus.Success, new PilotDto
                {
                    Pilot = pilot,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<PilotDto>(ResultStatus.Error, "Böyle bir Pilot Bulunamadı", null);
        }

        public async Task<IDataResult<PilotListDto>> GetAll()
        {
            var pilots = await _unitOfWork.Pilots.GetAllAsync(null, x => x.Results);
            if (pilots.Count >= -1)
            {
                return new DataResult<PilotListDto>(ResultStatus.Success, new PilotListDto
                {
                    Pilots = pilots,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<PilotListDto>(ResultStatus.Error, "Pilot List is not find", null);
        }

        public async Task<IDataResult<PilotListDto>> GetAllByNonDeleted()
        {
            var pilots = await _unitOfWork.Pilots.GetAllAsync(x => x.IsDeleted == false, x => x.Results);
            if (pilots.Count >= -1)
            {
                return new DataResult<PilotListDto>(ResultStatus.Success, new PilotListDto
                {
                    Pilots = pilots,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<PilotListDto>(ResultStatus.Error, "Kayıt listesi bulunamdı", null);
        }

        public async Task<IDataResult<PilotListDto>> GetAllByNonDeletedAndActive()
        {
            var pilots = await _unitOfWork.Pilots.GetAllAsync(x => x.IsDeleted == false && x.IsActive == true, x => x.Results);
            if (pilots.Count >= -1)
            {
                return new DataResult<PilotListDto>(ResultStatus.Success, new PilotListDto
                {
                    Pilots = pilots,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<PilotListDto>(ResultStatus.Error, "Böyle bir kayıt bulunamadı", null);
        }

        public async Task<IResult> HardDelete(int pilotId)
        {
            var pilot = await _unitOfWork.Pilots.GetAsync(x => x.Id == pilotId);
            if (pilot != null)
            {
                await _unitOfWork.Pilots.DeleteAsync(pilot).ContinueWith(x => _unitOfWork.SaveAsync());
                return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Success, $"{pilot.FirstName} Adlı Db'den Pilot Silinmiştir");
            }
            return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Error, $"{pilot.FirstName} Adlı Db'den Pilot bulunamadı", null);

        }

        public async Task<IResult> Update(PilotUpdateDto pilotUpdateDto)
        {
            var pilot = await _unitOfWork.Pilots.GetAsync(x => x.Id == pilotUpdateDto.Id);
            if (pilot != null)
            {
                pilot.FirstName = pilotUpdateDto.FirstName;
                pilot.LastName = pilotUpdateDto.LastName;
                pilot.Thumbnail = pilotUpdateDto.Thumbnail;
                pilot.Nationality = pilotUpdateDto.Nationality;
                pilot.DateOfBirth = pilotUpdateDto.DateOfBirth;
                pilot.IsActive = pilotUpdateDto.IsActive;
                await _unitOfWork.Pilots.UpdateAsync(pilot).ContinueWith(x => _unitOfWork.SaveAsync());
                return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Success, $"{pilotUpdateDto.FirstName} adlı kayıt düzenlendi");
            }
            return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Error, $"{pilot.FirstName} adlı kayıt bulunamadı");
        }
    }
}