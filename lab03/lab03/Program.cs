using lab03;
using lab03.Models;

class Program
{
    private static List<ContainerShip> _listShip = new List<ContainerShip>();

    public static void Main(string[] args)
    {
        /*
        Container container1 = new Container(212, 231, 100, 50, 1000);
        HazardLiquidContainer container2 = new HazardLiquidContainer(200, 200, 100, 50, 400);
        NormalLiquidContainer container3 = new NormalLiquidContainer(250, 250, 100, 60, 280);
        GasContainer container4 = new GasContainer(200, 250, 100, 40, 300, 100);
        RefrigeratedContainer container5 = new RefrigeratedContainer(210, 260, 240, 55, 1000, "Banan", 3.5f, 4);
        Container container6 = new Container(212, 231, 100, 50, 1000);

        Console.WriteLine("Stworzono następujące kontenery:");
        container1.PrintContainerData();
        container2.PrintContainerData();
        container3.printContainerData();
        container4.printContainerData();
        container5.printContainerData();
        container6.PrintContainerData();

        container1.Load(300);
        container1.PrintContainerData();
       // container2.Load(10);
       // container2.PrintContainerData();
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

        */
        Console.WriteLine("Witaj w programie!");

        string input;
        do
        {
            Opcje();
            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddShip();
                    break;
                case "2":
                    RemoveShip();
                    break;
                case "3":
                    AddContainer();
                    break;
                case "4":
                    PrintListShip();
                    break;
                default:
                    return;
            }
        } while (input != "5");
    }

    public static void Opcje()
    {
        Console.WriteLine("Możliwe akcje:");
        Console.WriteLine("1. Dodaj kontenerowiec");
        Console.WriteLine("2. Usuń kontenerowiec");
        Console.WriteLine("3. Dodaj kontener");
        Console.WriteLine("4. Wyświetl listę kontenerowców");
        Console.WriteLine("5. Wyjdź z programu");
        Console.Write("Wybierz akcję: ");
    }

    public static void AddShip()
    {
        Console.WriteLine("Podaj maksymalną prędkość:");
        int speed = int.Parse(Console.ReadLine());
        Console.WriteLine("Podaj maksymalną ilość kontenerów:");
        int containerNum = int.Parse(Console.ReadLine());
        Console.WriteLine("Podaj maksymalną ładowność:");
        float shipLoad = float.Parse(Console.ReadLine());

        ContainerShip containerShip = new ContainerShip(speed, containerNum, shipLoad);
        _listShip.Add(containerShip);
        Console.WriteLine("Dodano nowy kontenerowiec.");
    }

    public static void RemoveShip()
    {
        if (_listShip.Count == 0)
        {
            Console.WriteLine("Brak kontenerowców do usunięcia.");
            return;
        }

        Console.WriteLine("Lista kontenerowców:");
        for (int i = 0; i < _listShip.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. Statek (speed={_listShip[i].GetMaxSpeed()}, maxzContainerNum={_listShip[i].GetMaxContainerNumber()}, maxWeight={_listShip[i].GetMaxContainerWeight()})");
        }

        Console.WriteLine("Wybierz numer kontenerowca do usunięcia:");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= _listShip.Count)
        {
            Console.WriteLine("Nieprawidłowy numer kontenerowca.");
            return;
        }

        _listShip.RemoveAt(index);
        Console.WriteLine("Kontenerowiec został usunięty.");
    }

    public static void AddContainer()
    {
        Console.WriteLine("Jaki kontener chcesz dodać?");
        Console.WriteLine("1. Standardowy");
        Console.WriteLine("2. Na płyny");
        Console.WriteLine("3. Na gaz");
        Console.WriteLine("4. Chłodniczy");
        Console.WriteLine("5. Cofnij do menu");
        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                StandardContainer();
                break;
            case "2":
                AddLiquidContainer();
                break;
            case "3":
                AddGasContainer();
                break;
            case "4":
                AddRefrigeratedContainer();
                break;
            case "5":
                return;
            default:
                return;
        }
    }

    public static void PrintListShip()
    {
        if (_listShip.Count == 0)
        {
            Console.WriteLine("Brak kontenerowców.");
            return;
        }

        Console.WriteLine("Lista kontenerowców:");
        for (int i = 0; i < _listShip.Count; i++)
        {
            Console.WriteLine(
                $"Statek {i + 1}. (speed={_listShip[i].GetMaxSpeed()}, maxContainerNum={_listShip[i].GetMaxContainerNumber()}, maxWeight={_listShip[i].GetMaxContainerWeight()})");
        }
    }

    public static void StandardContainer()
    {
        Console.WriteLine("Podaj Wagę kontenera:");
        float weightCon = int.Parse(Console.ReadLine());
        Console.WriteLine("Podaj wage ładunku:");
        float load = int.Parse(Console.ReadLine());
        Console.WriteLine("Podaj wysokość:");
        float heigth = int.Parse(Console.ReadLine());
        Console.WriteLine("Podaj głębokość:");
        float depth = int.Parse(Console.ReadLine());
        Console.WriteLine("Podaj maksymalną ładowność:");
        float maxLoad = int.Parse(Console.ReadLine());

        Container container1 = new Container(load, heigth, weightCon, depth, maxLoad);
        Console.WriteLine("Do którego statku chcesz dodać kontener?");
        PrintListShip();
        int input = int.Parse(Console.ReadLine());

        if (input <= 0 || input > _listShip.Count)
        {
            Console.WriteLine("Nieprawidłowy numer statku.");
            return;
        }

        ContainerShip selectedShip = _listShip[input - 1];

        selectedShip.AddContainerToList(container1);
        Console.WriteLine("Dodano kontener do wybranego statku.");
    }

    public static void AddLiquidContainer()
    {
        Console.WriteLine("Jaki rodzaj produktu będzie w kontenerze?");
        Console.WriteLine("1. Normalny");
        NormalLiquidContainer normalLiquidContainer;
        Console.WriteLine("2. Niebezpieczny");
        HazardLiquidContainer hazardLiquidContainer;
        string input = Console.ReadLine();
        Console.WriteLine("Podaj wagę kontenera:");
        float weightCon = float.Parse(Console.ReadLine());
        Console.WriteLine("Podaj wagę ładunku:");
        float load = float.Parse(Console.ReadLine());
        Console.WriteLine("Podaj wysokość:");
        float heigth = float.Parse(Console.ReadLine());
        Console.WriteLine("Podaj głębokość:");
        float depth = float.Parse(Console.ReadLine());
        Console.WriteLine("Podaj maksymalną ładowność:");
        float maxLoad = float.Parse(Console.ReadLine());
        switch (input)
        {
            case "1":
                normalLiquidContainer = new NormalLiquidContainer(load, heigth, weightCon, depth, maxLoad);
                Console.WriteLine("Do którego statku chcesz dodać kontener na plyny?");
                PrintListShip();
                int input2 = int.Parse(Console.ReadLine());

                if (input2 <= 0 || input2 > _listShip.Count)
                {
                    Console.WriteLine("Nieprawidłowy numer statku.");
                    return;
                }

                ContainerShip selectedShip = _listShip[input2 - 1];

                selectedShip.AddContainerToList(normalLiquidContainer);
                Console.WriteLine("Dodano kontener na gaz do wybranego statku.");
                break;
            case "2":
                hazardLiquidContainer = new HazardLiquidContainer(load, heigth, weightCon, depth, maxLoad);
                Console.WriteLine("Do którego statku chcesz dodać kontener na plyny?");
                PrintListShip();
                int input3 = int.Parse(Console.ReadLine());

                if (input3 <= 0 || input3 > _listShip.Count)
                {
                    Console.WriteLine("Nieprawidłowy numer statku.");
                    return;
                }

                ContainerShip selectedShip2 = _listShip[input3 - 1];

                selectedShip2.AddContainerToList(hazardLiquidContainer);
                Console.WriteLine("Dodano kontener na gaz do wybranego statku.");
                break;
            default:
                return;
        }
        
        
    }
    

    public static void AddGasContainer()
    {
        Console.WriteLine("Podaj wagę kontenera:");
        float weightCon = float.Parse(Console.ReadLine());
        Console.WriteLine("Podaj wagę ładunku:");
        float load = float.Parse(Console.ReadLine());
        Console.WriteLine("Podaj wysokość:");
        float heigth = float.Parse(Console.ReadLine());
        Console.WriteLine("Podaj głębokość:");
        float depth = float.Parse(Console.ReadLine());
        Console.WriteLine("Podaj maksymalną ładowność:");
        float maxLoad = float.Parse(Console.ReadLine());
        Console.WriteLine("Podaj maksymalne ciśnienie:");
        float maxPressure = float.Parse(Console.ReadLine());

        GasContainer gasContainer = new GasContainer(load, heigth, weightCon, depth, maxLoad, maxPressure);

        Console.WriteLine("Do którego statku chcesz dodać kontener na gaz?");
        PrintListShip();
        int input = int.Parse(Console.ReadLine());

        if (input <= 0 || input > _listShip.Count)
        {
            Console.WriteLine("Nieprawidłowy numer statku.");
            return;
        }

        ContainerShip selectedShip = _listShip[input - 1];

        selectedShip.AddContainerToList(gasContainer);
        Console.WriteLine("Dodano kontener na gaz do wybranego statku.");
    }

    public static void AddRefrigeratedContainer()
    {
        Console.WriteLine("Podaj wagę chłodniczego kontenera:");
        float weightCon = float.Parse(Console.ReadLine());
        Console.WriteLine("Podaj wagę ładunku:");
        float load = float.Parse(Console.ReadLine());
        Console.WriteLine("Podaj wysokość:");
        float heigth = float.Parse(Console.ReadLine());
        Console.WriteLine("Podaj głębokość:");
        float depth = float.Parse(Console.ReadLine());
        Console.WriteLine("Podaj maksymalną ładowność:");
        float maxLoad = float.Parse(Console.ReadLine());
        Console.WriteLine("Podaj rodzaj ładunku:");
        string productType = Console.ReadLine();
        Console.WriteLine("Podaj wymaganą temperaturę:");
        float requiredTemperature = float.Parse(Console.ReadLine());
        Console.WriteLine("Podaj aktualna temperaturę:");
        float currentTemperature = float.Parse(Console.ReadLine());

        RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer(load, heigth, weightCon, depth, maxLoad,
            productType, requiredTemperature, currentTemperature);

        Console.WriteLine("Do którego statku chcesz dodać chłodniczy kontener?");
        PrintListShip();
        int input = int.Parse(Console.ReadLine());

        if (input <= 0 || input > _listShip.Count)
        {
            Console.WriteLine("Nieprawidłowy numer statku.");
            return;
        }

        ContainerShip selectedShip = _listShip[input - 1];

        selectedShip.AddContainerToList(refrigeratedContainer);
        Console.WriteLine("Dodano chłodniczy kontener do wybranego statku.");
    }
}