using FormulaOneInfo.Data.Abstract;
using FormulaOneInfo.Entities.Dtos.PilotDtos;
using FormulaOneInfo.Entities.Dtos.TeamDtos;
using FormulaOneInfo.Services.Abstract;
using FormulaOneInfo.Services.Concrete;
using FormulaOneInfo.Shared.Utilities.Result.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOneInfo.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController] 
    public class TeamController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITeamService _teamService;
        public TeamController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _teamService = new TeamManager(_unitOfWork);
        }
        [HttpGet] 
        [ActionName("GetAllTeams")]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await _teamService.GetAll();
            if (teams.ResultStatus == ResultStatus.Success)
                return Ok(teams);
            else if (teams.ResultStatus == ResultStatus.Error)
                return BadRequest(teams.Message);
            else
                return BadRequest();
        }
        [HttpGet]
        [ActionName("GetTeam")]
        public async Task<IActionResult> GetTeam(int id)
        {
            var team = await _teamService.Get(id);
            if (team.ResultStatus == ResultStatus.Success)
                return Ok(team);
            else if (team.ResultStatus == ResultStatus.Error)
                return BadRequest(team.Message);
            else
                return BadRequest();
        }
        [HttpGet]
        [ActionName("GetTeamsByNonDeleted")]
        public async Task<IActionResult> GetTeamsByNonDeleted(int id)
        {
            var teams = await _teamService.GetAllByNonDeleted();
            if (teams.ResultStatus == ResultStatus.Success)
                return Ok(teams);
            else if (teams.ResultStatus == ResultStatus.Error)
                return BadRequest(teams.Message);
            else
                return BadRequest();
        }
        [HttpGet]
        [ActionName("GetTeamsByNonAndActive")]
        public async Task<IActionResult> GetTeamsByNonAndActive()
        {
            var teams = await _teamService.GetAllByNonDeletedAndActive();
            if (teams.ResultStatus == ResultStatus.Success)
                return Ok(teams);
            else if (teams.ResultStatus == ResultStatus.Error)
                return BadRequest(teams.Message);
            else
                return BadRequest();
        }
        [HttpPost]
        [ActionName("AddTeam")]
        public async Task<IActionResult> AddPilot(TeamAddDto teamAddDtoAddDto)
        {
            var teams = await _teamService.Add(teamAddDtoAddDto);
            if (teams.ResultStatus == ResultStatus.Success)
                return Ok(teams.Message);
            else if (teams.ResultStatus == ResultStatus.Error)
                return BadRequest(teams.Message);
            else
                return BadRequest();
        }
        [HttpPut]
        [ActionName("UpdateTeam")]
        public async Task<IActionResult> UpdateTeam(TeamUpdateDto teamUpdateDto)
        {
            var teams = await _teamService.Update(teamUpdateDto);
            if (teams.ResultStatus == ResultStatus.Success)
                return Ok(teams.Message);
            else if (teams.ResultStatus == ResultStatus.Error)
                return BadRequest(teams.Message);
            else
                return BadRequest();
        }
        [HttpPut]
        [ActionName("DeleteTeam")]
        public async Task<IActionResult> DeleteTeam(int teamId)
        {
            var teams = await _teamService.Delete(teamId);
            if (teams.ResultStatus == ResultStatus.Success)
                return Ok(teams.Message);
            else if (teams.ResultStatus == ResultStatus.Error)
                return BadRequest(teams.Message);
            else
                return BadRequest();
        }
        [HttpDelete]
        [ActionName("HardDeleteTeam")]
        public async Task<IActionResult> HardDeleteTeam(int teamId)
        {
            var teams = await _teamService.HardDelete(teamId);
            if (teams.ResultStatus == ResultStatus.Success)
                return Ok(teams.Message);
            else if (teams.ResultStatus == ResultStatus.Error)
                return BadRequest(teams.Message);
            else
                return BadRequest();
        }

    }
}
