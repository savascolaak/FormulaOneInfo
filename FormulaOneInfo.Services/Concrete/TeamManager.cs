using FormulaOneInfo.Data.Concrete.EntityFramework;
using FormulaOneInfo.Entities.Concrete;
using FormulaOneInfo.Entities.Dtos.PilotDtos;
using FormulaOneInfo.Entities.Dtos.TeamDtos;
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
    public class TeamManager : ITeamService
    {
        private readonly UnitOfWork _unitOfWork;
        public TeamManager(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IResult> Add(TeamAddDto teamAddDto, string createdByName)
        {
            await _unitOfWork.Teams.AddAsync(new Team
            {
                Name = teamAddDto.Name,
                StartedDate = teamAddDto.StartedDate,
                Thumbnail = teamAddDto.Thumbnail,
                IsActive = teamAddDto.IsActive,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                Note = $"{teamAddDto.Name} adlı kayıt eklendi"
            }).ContinueWith(x=>_unitOfWork.SaveAsync());
            return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Success, $"{teamAddDto.Name} is Added");
        }

        public async Task<IResult> Delete(int teamId, string modifiedByName)
        {
            var team = await _unitOfWork.Teams.GetAsync(x => x.Id == teamId);
            if (team != null)
            {
                team.IsDeleted = true;
                await _unitOfWork.Teams.UpdateAsync(team).ContinueWith(t=>_unitOfWork.SaveAsync());
                return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Success, $"{team.Name} adlı kayıt silindi");
            }
            return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Error, $"{team.Name} adlı kayıt bulunamadı");
        }

        public async Task<IDataResult<TeamDto>> Get(int teamId)
        {
            var team = await _unitOfWork.Teams.GetAsync(x=>x.Id == teamId,x=>x.Results);
            if(team != null)
            {
                return new DataResult<TeamDto>(ResultStatus.Success, new TeamDto
                {
                    Team = team,
                    ResultStatus = ResultStatus.Success,

                });
            }
            return new DataResult<TeamDto>(ResultStatus.Error, "Böyle bir Takım Bulunamadı", null);
        }

        public async Task<IDataResult<TeamListDto>> GetAll()
        {
            var teams = await _unitOfWork.Teams.GetAllAsync(null,x=>x.Results);
            if(teams.Count >= -1)
            {
                return new DataResult<TeamListDto>(ResultStatus.Success, new TeamListDto
                {
                    Teams = teams,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<TeamListDto>(ResultStatus.Error,"Böyle bir team kaydı bulunamadı",null);
            
        }

        public async Task<IDataResult<TeamListDto>> GetAllByNonDeleted()
        {
            var teams = await _unitOfWork.Teams.GetAllAsync(x => x.IsDeleted == false, x => x.Results);
            if (teams.Count >= -1) 
            {
                return new DataResult<TeamListDto>(ResultStatus.Success, new TeamListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Teams = teams,
                });
            }
            return new DataResult<TeamListDto>(ResultStatus.Error, "Böyle bir team kaydı bulunamadı", null);
        }

        public async Task<IDataResult<TeamListDto>> GetAllByNonDeletedAndActive()
        {
            var teams = await _unitOfWork.Teams.GetAllAsync(x => x.IsDeleted == false && x.IsActive == true, x => x.Results);
            if(teams.Count >= -1)
            {
                return new DataResult<TeamListDto>(ResultStatus.Success, new TeamListDto
                {
                    Teams = teams,
                    ResultStatus= ResultStatus.Success,
                });
            }
            return new DataResult<TeamListDto>(ResultStatus.Error, "Böyle bir team kayıt bulunamadı", null);
        }

        public async Task<IResult> HardDelete(int teamId, string modifiedByName)
        {
            var team = await _unitOfWork.Teams.GetAsync(x => x.Id == teamId);
            if (team != null)
            {
                await _unitOfWork.Teams.DeleteAsync(team);
                return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Success, $"{team.Name} Adlı Db'den Pilot Silinmiştir");
            }
            return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Error, $"{team.Name} Adlı Db'den Team bulunamadı", null);
        }

        public async Task<IResult> Update(TeamUpdateDto teamUpdateDto, string modifiedByName)
        {
            var team = await _unitOfWork.Teams.GetAsync(x => x.Id == teamUpdateDto.Id);
            if (team != null) 
            {
                team.Name = teamUpdateDto.Name;
                team.StartedDate = teamUpdateDto.StartedDate;
                team.Thumbnail = teamUpdateDto.Thumbnail;
                team.IsActive = teamUpdateDto.IsActive;
                await _unitOfWork.Teams.UpdateAsync(team).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Success, $"{teamUpdateDto.Name} adlı kayıt düzenlendi");
            }
            return new Shared.Utilities.Result.Concrete.Result(ResultStatus.Error, $"{team.Name} adlı kayıt bulunamadı");
        }
    }
}
