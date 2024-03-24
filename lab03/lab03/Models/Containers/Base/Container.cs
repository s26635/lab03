namespace lab03;

public class Container
{
    protected float LoadWeigth { get; set; }
    protected float Heigth { get; set; }
    protected float ContainerWeigth { get; set; }
    protected float Depth { get; set; }
    protected string SerialNumber { get; set; }
    protected float MaxLoad { get; set; }
    private static int _numberOfContainers = 1;

    public Container(float loadWeigth, float heigth, float containerWeigth, float depth,
        float maxLoad, string containerType = "N")
    {
        LoadWeigth = loadWeigth;
        Heigth = heigth;
        ContainerWeigth = containerWeigth;
        Depth = depth;
        MaxLoad = maxLoad;
        GenerateSerialNumber(containerType);
    }

    public void GenerateSerialNumber(string type)
    {
        SerialNumber = $"KON-{type}-{_numberOfContainers}";
        _numberOfContainers++;
    }

    public void Deload(float deloadMass)
    {
        LoadWeigth -= deloadMass;
    }

    public void Empty()
    {
        LoadWeigth = 0;
    }

    public void Load(float loadMass)
    {
        if (loadMass > MaxLoad)
        {
            throw new OverfillException("Przekroczono dopuszczalny ładunek!");
        }
        else
        {
            LoadWeigth = loadMass;
        }
    }

    public string GetSerialNumber()
    {
        return SerialNumber;
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