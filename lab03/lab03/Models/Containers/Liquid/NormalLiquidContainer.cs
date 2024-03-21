namespace lab03.Models;

public class NormalLiquidContainer : Container
{
    public NormalLiquidContainer(float loadWeight, float height, float containerWeight, float depth, string serialNumber, float maxLoad)
        : base(loadWeight, height, containerWeight, depth, serialNumber, maxLoad)
    {
    }

    public void Load(float loadMass)
    {
        if (LoadWeigth + loadMass > 0.9f * MaxLoad)
        {
            // throw new OverfillException("Przekroczono 90% ładunku");
        }
        else
        {
            LoadWeigth += loadMass;
        }
    }
}