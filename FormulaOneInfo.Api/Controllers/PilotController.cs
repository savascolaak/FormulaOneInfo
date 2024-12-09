using FormulaOneInfo.Data.Abstract;
using FormulaOneInfo.Data.Concrete.EntityFramework;
using FormulaOneInfo.Entities.Concrete;
using FormulaOneInfo.Entities.Dtos.PilotDtos;
using FormulaOneInfo.Services.Abstract;
using FormulaOneInfo.Services.Concrete;
using FormulaOneInfo.Shared.Utilities.Result.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FormulaOneInfo.Shared.Utilities.Result.ComplexTypes;

namespace FormulaOneInfo.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PilotController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IPilotService _pilotService;
        public PilotController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _pilotService = new PilotManager(_unitOfWork);
        }

        [HttpGet]
        [ActionName("GetAllPilots")]
        public async Task<IActionResult> GetAllPilots()
        {
            var pilots = await _pilotService.GetAll();           
            if (pilots.ResultStatus == ResultStatus.Success)
                return Ok(pilots);
            else if (pilots.ResultStatus == ResultStatus.Error)
                return BadRequest(pilots.Message);
            else
                return BadRequest();
        }
        [HttpGet]
        [ActionName("GetPilot")]
        public async Task<IActionResult> GetPilot(int id)
        {
            var pilot = await _pilotService.Get(id);
            if (pilot.ResultStatus == ResultStatus.Success)
                return Ok(pilot);
            else if (pilot.ResultStatus == ResultStatus.Error)
                return BadRequest(pilot.Message);
            else
                return BadRequest();
        }
        [HttpGet]
        [ActionName("GetPilotByNonDeleted")]
        public async Task<IActionResult> GetPilotByNonDeleted(int id)
        {
            var pilots = await _pilotService.GetAllByNonDeleted();
            if (pilots.ResultStatus == ResultStatus.Success)
                return Ok(pilots);
            else if (pilots.ResultStatus == ResultStatus.Error)
                return BadRequest(pilots.Message);
            else
                return BadRequest();
        }
        [HttpGet]
        [ActionName("GetPilotByNonAndActive")]
        public async Task<IActionResult> GetPilotByNonAndActive()
        {
            var pilots = await _pilotService.GetAllByNonDeletedAndActive();
            if (pilots.ResultStatus == ResultStatus.Success)
                return Ok(pilots);
            else if (pilots.ResultStatus == ResultStatus.Error)
                return BadRequest(pilots.Message);
            else
                return BadRequest();
        }
        [HttpPost]
        [ActionName("AddPilot")]
        public async Task<IActionResult> AddPilot(PilotAddDto pilotAddDto)
        {
            var pilots = await _pilotService.Add(pilotAddDto);
            if (pilots.ResultStatus == ResultStatus.Success)
                return Ok(pilots.Message);
            else if (pilots.ResultStatus == ResultStatus.Error)
                return BadRequest(pilots.Message);
            else
                return BadRequest();
        }
        [HttpPut]
        [ActionName("UpdatePilot")]
        public async Task<IActionResult> UpdatePilot(PilotUpdateDto pilotUpdateDto)
        {
            var pilots = await _pilotService.Update(pilotUpdateDto);
            if (pilots.ResultStatus == ResultStatus.Success)
                return Ok(pilots.Message);
            else if (pilots.ResultStatus == ResultStatus.Error)
                return BadRequest(pilots.Message);
            else
                return BadRequest();
        }
        [HttpPut]
        [ActionName("DeletePilot")]
        public async Task<IActionResult> DeletePilot(int pilotId)
        {
            var pilots = await _pilotService.Delete(pilotId);
            if (pilots.ResultStatus == ResultStatus.Success)
                return Ok(pilots.Message);
            else if (pilots.ResultStatus == ResultStatus.Error)
                return BadRequest(pilots.Message);
            else
                return BadRequest();
        }
        [HttpDelete]
        [ActionName("HardDeletePilot")]
        public async Task<IActionResult> HardDeletePilot(int pilotId)
        {
            var pilots = await _pilotService.HardDelete(pilotId);
            if (pilots.ResultStatus == ResultStatus.Success)
                return Ok(pilots.Message);
            else if (pilots.ResultStatus == ResultStatus.Error)
                return BadRequest(pilots.Message);
            else
                return BadRequest();
        }     
    }
}
