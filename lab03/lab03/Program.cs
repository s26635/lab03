using lab03;
using lab03.Models;

class Program
{
    public static void Main(string[] args)
    {
        Container container1 = new Container(212, 231, 100, 50, 1000, "N");
        HazardLiquidContainer container2 = new HazardLiquidContainer(200, 200, 100, 50, 400, "HL");
        NormalLiquidContainer container3 = new NormalLiquidContainer(250, 250, 100, 60, 280, "NL");
        GasContainer container4 = new GasContainer(200, 250, 100, 40, 300, "G", 100);
        RefrigeratedContainer container5 = new RefrigeratedContainer(210, 260, 240, 55, 1000, "R", "Banan", 3.5f, 4);
        Console.WriteLine("Stworzono następujące kontenery:");
        container1.PrintContainerData();
        container2.printContainerData();
        container3.printContainerData();
        container4.printContainerData();
        container5.printContainerData();
        
        container1.Load(300);
        container1.PrintContainerData();
       // container2.Load(10);
       // container2.printContainerData();
        List<Container> listContainer = new List<Container>();
        listContainer.Add(container1);
        listContainer.Add(container2);
        listContainer.Add(container3);
        listContainer.Add(container4);
        
        ContainerShip containerShip = new ContainerShip(100, 8, 5000);
        containerShip.PrintContainerShipData();
        containerShip.AddContainerToList(container5);
        containerShip.PrintContainerList();
        containerShip.LoadShip(listContainer);
        containerShip.PrintContainerShipData();
        containerShip.DeloadContainerFromShip(container1);
        containerShip.PrintContainerShipData();
        containerShip.ChangeContainer(container2.GetSerialNumber(),container1);
        containerShip.PrintContainerShipData();
    }
}