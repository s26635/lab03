namespace lab03.Models;

public class NormalLiquidContainer : Container
{
    public NormalLiquidContainer(float loadWeigth, float heigth, float containerWeigth, float depth, string serialNumber, float maxLoad, char containerType) : base(loadWeigth, heigth, containerWeigth, depth, serialNumber, maxLoad, containerType)
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