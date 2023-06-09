using FluentValidationDemo.DAL;
using FluentValidationDemo.Domain;
using FluentValidationDemo.ValidationStaff;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotherBoardController : ControllerBase
    {
        private readonly ILogger<MotherBoardController> _logger;
        private readonly IMotherBoardRepository _motherBoardRepository;

        public MotherBoardController(ILogger<MotherBoardController> logger, IMotherBoardRepository motherBoardRepository)
        {
            _logger = logger;
            _motherBoardRepository= motherBoardRepository;
        }

        [HttpPost("/motherBoard")]
        public async Task<IActionResult> CreateWithValidate([FromQuery] MotherBoard motherBoard)
        {
            try
            {
                var result = await _motherBoardRepository.AddAsync(motherBoard);
                _logger.LogInformation("create motherboard");

                return Created("/motherBoard", result);
            }
            catch (Exception ex)
            {

                return Problem(detail: ex.Message);
            }
        }

        [HttpPost("/motherBoard/validation")]
        public async Task<IActionResult> Create([FromQuery]MotherBoard motherBoard)
        {
            try
            {
                var validResult = motherBoard.IsValidModel();
                if (validResult.IsValid())
                {
                    var result = await _motherBoardRepository.AddAsync(motherBoard);
                    _logger.LogInformation("create motherboard");

                    return Created("/motherBoard", result);
                }

                return BadRequest(validResult.ToString());
            }
            catch (Exception ex)
            {

                return Problem(detail: ex.Message);
            }
        }

        [HttpGet("/motherBoard")]
        public IActionResult Get()
        {
            try
            {
                var result = _motherBoardRepository.GetAll();
                _logger.LogInformation("get motherboards");

                return Ok(result);
            }
            catch (Exception ex)
            {

                return Problem(detail: ex.Message);
            }
        }

        [HttpDelete("/motherBoard")]
        public IActionResult Get([FromQuery] Guid id)
        {
            try
            {
                var result = _motherBoardRepository.GetAll()
                    .Where(x => x.Id == id).SingleOrDefault();

                if (result != null)
                {
                    var deleteResult = _motherBoardRepository.Delete(result);
                    
                    return Ok($"{(deleteResult ? "success" : "faail")} delete");
                }

                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(detail: ex.Message);
            }
        }
    }
}