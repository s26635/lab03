using System.Text;

namespace lab03.Models;

public class ContainerShip
{
    private List<Container> Containers { get; set; }
    private float MaxSpeed { get; set; }
    private int MaxContainerNumber { get; set; }
    private float MaxContainerWeight { get; set; }

    public ContainerShip(float maxSpeed, int maxContainerNumber, float maxContainerWeight)
    {
        MaxSpeed = maxSpeed;
        MaxContainerNumber = maxContainerNumber;
        MaxContainerWeight = maxContainerWeight;
        Containers = new List<Container>();
    }

    public void AddContainerToList(Container container)
    {
        if (Containers.Count < MaxContainerNumber)
        {
            Containers.Add(container);
        }
        else
        {
            //error
        }
    }

    public void LoadShip(List<Container> containers)
    {
        if (Containers == null)
        {
            Containers = containers;
        }
        else
        {
            foreach (Container c in containers)
            {
                AddContainerToList(c);
            }
        }
    }

    public void DeloadContainerFromShip(Container container)
    {
        Containers.Remove(container);
    }

    public void ChangeContainer(string containerToChange, Container containerToLoad)
    {
        Containers.Remove(Containers.First(c => c.GetSerialNumber() == containerToChange));
        Containers.Add(containerToLoad);
    }
    public void PrintContainerShipData()
    {
        
        StringBuilder kontenery = new StringBuilder();
        foreach (var container in Containers)
        {
            kontenery.Append(container.GetSerialNumber());
            kontenery.Append(" ");
        }

        string konteneryString = kontenery.ToString();
        konteneryString += "\n";
        string toPrint = "Lista kontenerów na statku: "+ konteneryString+
                         "Maksymalna prędkość statku: " + MaxSpeed +"\n"+
                         "Maksymalna dozwolona ilość kontnerów: " + MaxContainerNumber +"\n"+
                         "Maksymalna dozwolona waga kontenerów: " + MaxContainerWeight;
        
        Console.WriteLine(toPrint);
    }

    public void PrintContainerList()
    {
        StringBuilder resultBuilder = new StringBuilder();
        foreach (var container in Containers)
        {
            resultBuilder.Append(container.GetSerialNumber());
            resultBuilder.Append(" ");
        }

        string result = resultBuilder.ToString();
        Console.WriteLine(result);
    }
}