using EB.Sensors.SignalR.Features.SensorData.Delegates;
using EB.Sensors.SignalR.Features.SensorData.Observables;

namespace EB.Sensors.SignalR.Features.SensorData.Observers;

using SensorData = EB.Sensors.Infrastructure.Models.SensorData;

public class SensorDataMonitor : IObserver<SensorData>
{
    private IDisposable? _cancellation;
    
    private readonly ILogger<SensorDataMonitor> _logger;
    private readonly string _name;
    private SensorDataDelegates.ReceiveSensorDataDelegate _receiveEvent;
    private readonly List<SensorData> _sensorData = new();

    public SensorDataMonitor(ILogger<SensorDataMonitor> logger, string name, SensorDataDelegates.ReceiveSensorDataDelegate receiveEvent)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name), "Observer must be assigned a name");
        
        _logger = logger;
        _name = name;
        _receiveEvent = receiveEvent;
    }
    
    public virtual void Subscribe(SensorDataHandler provider)
    {
        _cancellation = provider.Subscribe(this);
    }

    public virtual void Unsubscribe()
    {
        if (_cancellation == null)
        {
            _logger.LogError("There is no active subscription to unsubscribe from");
            return;
        }
        
        // Cleanup
        _cancellation.Dispose();
        _sensorData.Clear();
    }

    public void OnCompleted()
    {
        _sensorData.Clear();
    }

    public void OnError(Exception error)
    {
        _logger.LogError(exception: error, "An exception was thrown by the provider");
        throw error;
    }

    public void OnNext(SensorData value)
    {
        if (_sensorData.Contains(value))
        {
            _logger.LogInformation("Data collection already contains data to add");
            return;
        }
        
        _sensorData.Add(value);
        _receiveEvent.Invoke(value);
    }
}