using EB.Sensors.Infrastructure.Models;

namespace EB.Sensors.Statistics.Features.Statistics.Services;

public interface IStatisticsService
{
    Task<IEnumerable<Projection>> GetProjections(DateTime startDate, TimeSpan timeSpan);
}