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
        Containers.Remove(Containers.FirstOrDefault(c => c.getSerialNumber() == containerToChange));
        Containers.Add(containerToLoad);
    }
    
}