using lab03.Interfaces;

namespace lab03.Models;

public class GasContainer : Container, IHazardNotifier
{
    protected float Pressure { set; get; }
    

    public GasContainer(float loadWeigth, float heigth, float containerWeigth, float depth, float maxLoad, float pressure) : base(loadWeigth, heigth, containerWeigth, depth, maxLoad, "G")
    {
        Pressure = pressure;
        Load(LoadWeigth);
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
            throw new OverfillException("Przekroczono dopuszczalną masę!");
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
    
    public void printContainerData()
    {
        string toPrint = "Aktualnie załadowana waga: " + LoadWeigth +
                         " Ciśnienie: "+Pressure+
                         " Numer seryjny kontenera: " + SerialNumber +
                         " Maksymalna ładowność: " + MaxLoad +
                         " Waga kontenera: " + ContainerWeigth +
                         " Wysokość: " + Heigth +
                         " Głebkokość: " + Depth;
        Console.WriteLine(toPrint);
    }
}