using EB.Sensors.Infrastructure.Models;
using EB.Sensors.Statistics.Features.Statistics.Services;
using Microsoft.AspNetCore.Mvc;

namespace EB.Sensors.Statistics.Features.Statistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }
        
        // TODO: Add and implement endpoints for getting statistics data

        [HttpGet("projections")]
        public async Task<IEnumerable<Projection>> GetProjections(DateTime startDate, TimeSpan timeSpan)
        {
            if (startDate.Equals(default))
                throw new ArgumentOutOfRangeException(nameof(startDate));
            
            if (timeSpan.Equals(default))
                throw new ArgumentOutOfRangeException(nameof(timeSpan));
            
            return await _statisticsService.GetProjections(startDate, timeSpan);
        }
    }
}
