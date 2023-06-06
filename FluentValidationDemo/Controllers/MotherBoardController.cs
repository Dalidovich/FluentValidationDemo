using FluentValidation.AspNetCore;
using FluentValidationDemo.DAL;
using FluentValidationDemo.Domain;
using FluentValidationDemo.Validation;
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

        [HttpPost("/motherBoard/standart")]
        public async Task<IActionResult> Create([FromQuery] MotherBoard motherBoard)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _motherBoardRepository.AddAsync(motherBoard);
                    _logger.LogInformation("create motherboard");

                    return Created("/motherBoard", result);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {

                return Problem(detail: ex.Message);
            }
        }

        [HttpPost("/motherBoard/lite")]
        public async Task<IActionResult> CreateStrict([FromQuery]
            [CustomizeValidator(Properties = $"{ValidationModelProppety.RAMMax},{ValidationModelProppety.RAMSlots}")] 
            MotherBoard motherBoard)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _motherBoardRepository.AddAsync(motherBoard);
                    _logger.LogInformation("create motherboard");

                    return Created("/motherBoard", result);
                }

                return BadRequest();
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