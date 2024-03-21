using lab03.Interfaces;

namespace lab03.Models;

public class GasContainer : Container, IHazardNotifier
{
    protected float Pressure { set; get; }
    
    public GasContainer(float loadWeigth, float heigth, float containerWeigth, float depth, string serialNumber, float maxLoad) : base(loadWeigth, heigth, containerWeigth, depth, serialNumber, maxLoad)
    {
        
    }

    public void Deload(float deloadMass)
    {
        if (LoadWeigth-deloadMass < 0.05*LoadWeigth)
        {
            Notify();
        }
        else
        {
            LoadWeigth -= deloadMass;
        }
    }

    public void Load(float loadMass)
    {
        if (LoadWeigth+loadMass > MaxLoad)
        {
            throw new OverfillException();
        }
        else
        {
            LoadWeigth += loadMass;
        }
    }
    public void Notify()
    {
        Console.WriteLine("Dangerous situation for container: "+ SerialNumber);
    }
}