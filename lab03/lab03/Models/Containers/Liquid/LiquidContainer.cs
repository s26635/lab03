using lab03.Interfaces;

namespace lab03.Models;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool IsHazard { get; set; }

    public LiquidContainer(float loadWeigth, float heigth, float containerWeigth, float depth, string serialNumber,
        float maxLoad, bool isHazard) : base(loadWeigth, heigth, containerWeigth, depth, serialNumber, maxLoad)
    {
        IsHazard = isHazard;
    }

    public void Notify()
    {
        Console.WriteLine("Dangerous situation for container: "+ SerialNumber);
    }

    
    public void Load(float loadMass)
    {
        if (IsHazard)
        {
            if (LoadWeigth+loadMass > (0.5)*MaxLoad)
            {
                throw new OverFillDangerousException(50);
            }
            else
            {
                LoadWeigth += loadMass;
            }
        }
        else
        {
            if (LoadWeigth+loadMass > (0.9)*MaxLoad)
            {
                // throw new OverfillException("Przekroczono 90% ładunku");
            }
            else
            {
                LoadWeigth += loadMass;
            }
        }
    }
}