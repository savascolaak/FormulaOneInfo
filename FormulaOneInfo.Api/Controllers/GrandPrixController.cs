using FormulaOneInfo.Data.Abstract;
using FormulaOneInfo.Entities.Dtos.GrandPrixDtos;
using FormulaOneInfo.Services.Abstract;
using FormulaOneInfo.Services.Concrete;
using FormulaOneInfo.Shared.Utilities.Result.ComplexTypes;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOneInfo.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GrandPrixController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGrandPrixService _grandPrixService;
        public GrandPrixController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _grandPrixService = new GrandPrixManager(_unitOfWork);
        }
        [HttpGet]
        [ActionName("GetAllGrandPrixes")]
        public async Task<IActionResult> GetAllGrandPrixes()
        {
            var grandPrixes = await _grandPrixService.GetAll();
            if (grandPrixes.ResultStatus == ResultStatus.Success)
                return Ok(grandPrixes);
            else if (grandPrixes.ResultStatus == ResultStatus.Error)
                return BadRequest(grandPrixes.Message);
            else
                return BadRequest();
        }
        [HttpGet]
        [ActionName("GetGrandPrixes")]
        public async Task<IActionResult> GetGrandPrixes(int id)
        {
            var grandPrixes = await _grandPrixService.Get(id);
            if (grandPrixes.ResultStatus == ResultStatus.Success)
                return Ok(grandPrixes);
            else if (grandPrixes.ResultStatus == ResultStatus.Error)
                return BadRequest(grandPrixes.Message);
            else
                return BadRequest();
        }
        [HttpGet]
        [ActionName("GetGrandPrixesByNonDeleted")]
        public async Task<IActionResult> GetGrandPrixesByNonDeleted(int id)
        {
            var grandPrixes = await _grandPrixService.GetAllByNonDeleted();
            if (grandPrixes.ResultStatus == ResultStatus.Success)
                return Ok(grandPrixes);
            else if (grandPrixes.ResultStatus == ResultStatus.Error)
                return BadRequest(grandPrixes.Message);
            else
                return BadRequest();
        }
        [HttpGet]
        [ActionName("GetGrandPrixesByNonAndActive")]
        public async Task<IActionResult> GetGrandPrixesByNonAndActive()
        {
            var grandPrixes = await _grandPrixService.GetAllByNonDeletedAndActive();
            if (grandPrixes.ResultStatus == ResultStatus.Success)
                return Ok(grandPrixes);
            else if (grandPrixes.ResultStatus == ResultStatus.Error)
                return BadRequest(grandPrixes.Message);
            else
                return BadRequest();
        }
        [HttpPost]
        [ActionName("AddGrandPrix")]
        public async Task<IActionResult> AddGrandPrix(GrandPrixAddDto grandPrixAddDto)
        {
            var grandPrixes = await _grandPrixService.Add(grandPrixAddDto);
            if (grandPrixes.ResultStatus == ResultStatus.Success)
                return Ok(grandPrixes.Message);
            else if (grandPrixes.ResultStatus == ResultStatus.Error)
                return BadRequest(grandPrixes.Message);
            else
                return BadRequest();
        }
        [HttpPut]
        [ActionName("UpdateGrandPrix")]
        public async Task<IActionResult> UpdateGrandPrix(GrandPrixUpdateDto grandPrixUpdateDto)
        {
            var grandPrixes = await _grandPrixService.Update(grandPrixUpdateDto);
            if (grandPrixes.ResultStatus == ResultStatus.Success)
                return Ok(grandPrixes.Message);
            else if (grandPrixes.ResultStatus == ResultStatus.Error)
                return BadRequest(grandPrixes.Message);
            else
                return BadRequest();
        }
        [HttpPut]
        [ActionName("DeleteGrandPrix")]
        public async Task<IActionResult> DeleteGrandPrix(int grandPrixId)
        {
            var grandPrixes = await _grandPrixService.Delete(grandPrixId);
            if (grandPrixes.ResultStatus == ResultStatus.Success)
                return Ok(grandPrixes.Message);
            else if (grandPrixes.ResultStatus == ResultStatus.Error)
                return BadRequest(grandPrixes.Message);
            else
                return BadRequest();
        }
        [HttpDelete]
        [ActionName("HardDeleteGrandPrix")]
        public async Task<IActionResult> HardDeleteGrandPrix(int grandPrixId)
        {
            var grandPrixes = await _grandPrixService.HardDelete(grandPrixId);
            if (grandPrixes.ResultStatus == ResultStatus.Success)
                return Ok(grandPrixes.Message);
            else if (grandPrixes.ResultStatus == ResultStatus.Error)
                return BadRequest(grandPrixes.Message);
            else
                return BadRequest();
        }
    }
}
