using EB.Sensors.Infrastructure.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace EB.Sensors.Statistics.Features.Statistics.Services;

public class StatisticsService : IStatisticsService
{
    private void InitializeConnection()
    {
        /*
        var connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:53353/ChatHub")
            .Build();
            */
    }

    public async Task<IEnumerable<Projection>> GetProjections(DateTime startDate, TimeSpan timeSpan)
    {
        throw new NotImplementedException();
    }
}