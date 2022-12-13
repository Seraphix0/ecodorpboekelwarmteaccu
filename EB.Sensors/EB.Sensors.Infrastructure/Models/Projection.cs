namespace EB.Sensors.Infrastructure.Models;

public class Projection
{
    public Projection(DateTime created, DateTime modified, EnergyProjection energyProjection, 
        GasProjection gasProjection, Co2Projection co2Projection)
    {
        Created = created;
        Modified = modified;
        EnergyProjection = energyProjection;
        GasProjection = gasProjection;
        Co2Projection = co2Projection;
    }
    
    public DateTime Created { get; }
    public DateTime Modified { get; }
    
    public EnergyProjection EnergyProjection { get; }
    public GasProjection GasProjection { get; }
    public Co2Projection Co2Projection { get; }
}

public class EnergyProjection
{
    public decimal Heat { get; set; }
    public decimal HeatIncrease { get; set; }
    public decimal HeatDecrease { get; set; }
    public decimal NewHeat { get; set; }
    public decimal KwhProduction { get; set; }
}

public class GasProjection
{
    public decimal GasEquivalent { get; set; }
    public decimal GasFixedCostEquivalent { get; set; }
    public decimal GasVariableCostEquivalent { get; set; }
    public decimal GasTotalCostEquivalent { get; set; }
}

public class Co2Projection
{
    public decimal Co2Equivalent { get; set; }
}