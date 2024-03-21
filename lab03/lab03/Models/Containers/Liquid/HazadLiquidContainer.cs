using lab03.Interfaces;

namespace lab03.Models;

public class HazardLiquidContainer : Container, IHazardNotifier
{
    public HazardLiquidContainer(float loadWeigth, float heigth, float containerWeigth, float depth, string serialNumber, float maxLoad, char containerType) : base(loadWeigth, heigth, containerWeigth, depth, serialNumber, maxLoad, containerType)
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