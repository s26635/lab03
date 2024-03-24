using lab03.Interfaces;

namespace lab03.Models;

public class HazardLiquidContainer : Container, IHazardNotifier
{
    public HazardLiquidContainer(float loadWeigth, float heigth, float containerWeigth, float depth, float maxLoad) : base(loadWeigth, heigth, containerWeigth, depth, maxLoad, "HL")
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
    
    public new void PrintContainerData()
    {
        string toPrint = "Aktualnie załadowana waga: " + LoadWeigth +
                         " Numer seryjny kontenera: " + SerialNumber +
                         " Maksymalna ładowność: " + MaxLoad +
                         " Waga kontenera: " + ContainerWeigth +
                         " Wysokość: " + Heigth +
                         " Głebkokość: " + Depth;
        Console.WriteLine(toPrint);
    }
}