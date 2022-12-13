using Microsoft.AspNetCore.SignalR.Client;

namespace EB.Sensors.Statistics.Features.Statistics.Services;

public class StatisticsService
{
    private void InitializeConnection()
    {
        var connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:53353/ChatHub")
            .Build();
    }
}