namespace lab03;

public class Container
{
    protected float LoadWeigth { get; set; }
    protected float Heigth { get; set; }
    protected float ContainerWeigth { get; set; }
    protected float Depth { get; set; }
    protected string SerialNumber { get; set; }
    protected float MaxLoad { get; set; }
    private static int numberOfContainers = 1;

    public Container(float loadWeigth, float heigth, float containerWeigth, float depth, string serialNumber,
        float maxLoad, char containerType)
    {
        LoadWeigth = loadWeigth;
        Heigth = heigth;
        ContainerWeigth = containerWeigth;
        Depth = depth;
        MaxLoad = maxLoad;
        SerialNumber = GenerateSerialNumber(containerType);
    }

    public string GenerateSerialNumber(char type)
    {
        string result = $"KON-{type}-{numberOfContainers}";
        numberOfContainers++;
        return result;
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
            throw new OverfillException();
        }
        else
        {
            LoadWeigth = loadMass;
        }
    }

    public string getSerialNumber()
    {
        return SerialNumber;
    }
}