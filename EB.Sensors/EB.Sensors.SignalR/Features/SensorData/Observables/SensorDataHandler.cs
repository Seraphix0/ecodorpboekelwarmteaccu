using EB.Sensors.Infrastructure.Unsubscriber;

namespace EB.Sensors.SignalR.Features.SensorData.Observables;

using SensorData = EB.Sensors.Infrastructure.Models.SensorData;

public class SensorDataHandler : IObservable<SensorData>
{
    private readonly ILogger<SensorDataHandler> _logger;
    private readonly List<IObserver<SensorData>> _observers = new();
    private readonly List<SensorData> _data = new();

    public SensorDataHandler(ILogger<SensorDataHandler> logger)
    {
        _logger = logger;
    }
    
    public IDisposable Subscribe(IObserver<SensorData> observer)
    {
        // Check whether observer is already registered. If not, add it
        if (_observers.Contains(observer)) 
            return new EB.Sensors.Infrastructure.Unsubscriber.Unsubscriber<SensorData>(_observers, observer);
        
        _observers.Add(observer);
        
        // Provide observer with existing data.
        foreach (var item in _data)
            observer.OnNext(item);

        return new Unsubscriber<SensorData>(_observers, observer);
    }

    public void AddData(SensorData data)
    {
        if (_data.Contains(data))
        {
            _logger.LogError("Data collection already contains data to add");
            return;
        }

        _data.Add(data);
    }

    public void ClearData()
    {
        _data.Clear();
    }
}