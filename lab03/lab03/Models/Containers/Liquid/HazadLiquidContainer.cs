using lab03.Interfaces;

namespace lab03.Models;

public class HazardLiquidContainer : Container, IHazardNotifier
{
    public HazardLiquidContainer(float loadWeight, float height, float containerWeight, float depth, string serialNumber, float maxLoad)
        : base(loadWeight, height, containerWeight, depth, serialNumber, maxLoad)
    {
    }

    public void Load(float loadMass)
    {
        if (LoadWeigth + loadMass > 0.5f * MaxLoad)
        {
            throw new OverFillDangerousException(50);
        }
        else
        {
            LoadWeigth += loadMass;
        }
    }

    public void Notify()
    {
        Console.WriteLine("Dangerous situation for container: " + SerialNumber);
    }
}