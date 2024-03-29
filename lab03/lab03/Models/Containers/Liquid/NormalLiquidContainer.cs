﻿namespace lab03.Models;

public class NormalLiquidContainer : Container
{
    public NormalLiquidContainer(float loadWeigth, float heigth, float containerWeigth, float depth, float maxLoad) : base(loadWeigth, heigth, containerWeigth, depth, maxLoad, "NL")
    {
        Load(LoadWeigth);
    }

    public void Load(float loadMass)
    {
        if (LoadWeigth + loadMass > 0.9f * MaxLoad)
        {
            Notify();
            throw new OverfillException("Przekroczono 90% ładunku!");
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
    
    public void PrintContainerData()
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