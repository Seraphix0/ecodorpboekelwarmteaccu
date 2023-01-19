using EB.Sensors.SignalR.Features.SensorData.Delegates;
using EB.Sensors.SignalR.Features.SensorData.Observables;
using EB.Sensors.SignalR.Features.SensorData.Observers;
using Microsoft.AspNetCore.SignalR;

namespace EB.Sensors.SignalR.Features.SensorData.Hubs;

public class SensorHub : Hub
{
    private readonly ILogger<SensorHub> _logger;
    private readonly SensorDataHandler _sensorDataProvider;
    
    public event SensorDataDelegates.ReceiveSensorDataDelegate ReceiveSensorDataEvent;

    public SensorHub(ILogger<SensorHub> logger, ILoggerFactory factory)
    {
        ReceiveSensorDataEvent += async (value) => await ReceiveSensorData(value);
        
        _logger = logger;
        
        _sensorDataProvider = new SensorDataHandler(
            factory.CreateLogger<SensorDataHandler>());
    }

    public async Task ReceiveSensorData(Infrastructure.Models.SensorData data)
    {
        _sensorDataProvider.AddData(data);

        await Clients.All.SendAsync("ReceiveSensorData", data.SensorId, data.Value, data.Created);
    }
}