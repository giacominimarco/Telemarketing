using Microsoft.AspNetCore.Mvc;
using Telemarketing.DTOs;
using Telemarketing.Services;

namespace Telemarketing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndicatorController : Controller
    {
        private readonly IIndicatorService _indicatorService;
        public IndicatorController(IIndicatorService indicatorService) { 
        
            _indicatorService = indicatorService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            List<IndicatorDTO> indicators = await _indicatorService.GetAll();
            return Ok(indicators);
        }
        
        [HttpGet("GetCalcByIndicatorId")]
        public async Task<IActionResult> GetCalcByIndicatorId([FromQuery] int indicatorId)
        {
            IndicatorDTO indicator = await _indicatorService.GetCalcByIndicatorId(indicatorId);
            return Ok(indicator);
        }
        
        [HttpPut("UpdateCollect")]
        public async Task<IActionResult> UpdateCollect([FromBody] CollectUpdateDTO collectUpdate)
        {
            bool update = await _indicatorService.UpdateCollect(collectUpdate);
            return Ok(update);
        }
        
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] IndicatorDTO indicator)
        {
            if (indicator == null || indicator.TypeCalc == null || string.IsNullOrEmpty(indicator.Name))
            {
                return BadRequest("Invalid indicator data.");
            }

            bool answerCreateIndicator = await _indicatorService.Create(indicator);
            return Ok(answerCreateIndicator);
        }
    }
}
