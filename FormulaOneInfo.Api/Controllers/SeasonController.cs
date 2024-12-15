using FormulaOneInfo.Data.Abstract;
using FormulaOneInfo.Entities.Dtos.SeasonDtos;
using FormulaOneInfo.Services.Abstract;
using FormulaOneInfo.Services.Concrete;
using FormulaOneInfo.Shared.Utilities.Result.ComplexTypes;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOneInfo.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISeasonService _seasonService;
        public SeasonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _seasonService = new SeasonManager(_unitOfWork);
        }

        [HttpGet]
        [ActionName("GetAllSeasons")]
        public async Task<IActionResult> GetAllSeasons()
        {
            var seasons = await _seasonService.GetAll();
            if (seasons.ResultStatus == ResultStatus.Success)
                return Ok(seasons);
            else if (seasons.ResultStatus == ResultStatus.Error)
                return BadRequest(seasons.Message);
            else
                return BadRequest();
        }
        [HttpGet]
        [ActionName("GetSeason")]
        public async Task<IActionResult> GetSeason(int id)
        {
            var seasons = await _seasonService.Get(id);
            if (seasons.ResultStatus == ResultStatus.Success)
                return Ok(seasons);
            else if (seasons.ResultStatus == ResultStatus.Error)
                return BadRequest(seasons.Message);
            else
                return BadRequest();
        }
        [HttpGet]
        [ActionName("GetSeasonsByNonDeleted")]
        public async Task<IActionResult> GetSeasonsByNonDeleted(int id)
        {
            var seasons = await _seasonService.GetAllByNonDeleted();
            if (seasons.ResultStatus == ResultStatus.Success)
                return Ok(seasons);
            else if (seasons.ResultStatus == ResultStatus.Error)
                return BadRequest(seasons.Message);
            else
                return BadRequest();
        }
        [HttpGet]
        [ActionName("GetSeasonsByNonAndActive")]
        public async Task<IActionResult> GetSeasonsByNonAndActive()
        {
            var seasons = await _seasonService.GetAllByNonDeletedAndActive();
            if (seasons.ResultStatus == ResultStatus.Success)
                return Ok(seasons);
            else if (seasons.ResultStatus == ResultStatus.Error)
                return BadRequest(seasons.Message);
            else
                return BadRequest();
        }
        [HttpPost]
        [ActionName("AddSeason")]
        public async Task<IActionResult> AddSeason(SeasonAddDto seasonAddDto)
        {
            var seasons = await _seasonService.Add(seasonAddDto);
            if (seasons.ResultStatus == ResultStatus.Success)
                return Ok(seasons.Message);
            else if (seasons.ResultStatus == ResultStatus.Error)
                return BadRequest(seasons.Message);
            else
                return BadRequest();
        }
        [HttpPut]
        [ActionName("UpdateSeason")]
        public async Task<IActionResult> UpdateSeason(SeasonUpdateDto seasonUpdateDto)
        {
            var seasons = await _seasonService.Update(seasonUpdateDto);
            if (seasons.ResultStatus == ResultStatus.Success)
                return Ok(seasons.Message);
            else if (seasons.ResultStatus == ResultStatus.Error)
                return BadRequest(seasons.Message);
            else
                return BadRequest();
        }
        [HttpPut]
        [ActionName("DeleteSeason")]
        public async Task<IActionResult> DeleteSeason(int seasonId)
        {
            var seasons = await _seasonService.Delete(seasonId);
            if (seasons.ResultStatus == ResultStatus.Success)
                return Ok(seasons.Message);
            else if (seasons.ResultStatus == ResultStatus.Error)
                return BadRequest(seasons.Message);
            else
                return BadRequest();
        }
        [HttpDelete]
        [ActionName("HardDeleteSeason")]
        public async Task<IActionResult> HardDeleteSeason(int seasonId)
        {
            var seasons = await _seasonService.HardDelete(seasonId);
            if (seasons.ResultStatus == ResultStatus.Success)
                return Ok(seasons.Message);
            else if (seasons.ResultStatus == ResultStatus.Error)
                return BadRequest(seasons.Message);
            else
                return BadRequest();
        }

    }
}
