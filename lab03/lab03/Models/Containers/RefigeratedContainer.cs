namespace lab03.Models;

 public class RefrigeratedContainer : Container
    {
        public string ProductType { get; }
        public float RequiredTemperature { get; }
        public float CurrentTemperature { get; private set; }



        public RefrigeratedContainer(float loadWeigth, float heigth, float containerWeigth, float depth, float maxLoad, string productType, float requiredTemperature, float currentTemperature) : base(loadWeigth, heigth, containerWeigth, depth, maxLoad, "R")
        {
            ProductType = productType;
            RequiredTemperature = requiredTemperature;
            CurrentTemperature = currentTemperature;
        }

        public void Load(float loadMass, string productType, float requiredTemperature)
        {
            if (ProductType != productType)
            {
                throw new InvalidProductException("Zły rodzaj produktu");
            }
            if (LoadWeigth + loadMass > MaxLoad)
            {
               throw new OverloadException("Przekroczono dopuszczalną ładowność kontenera");
            }
            if (CurrentTemperature < requiredTemperature)
            {
                throw new InvalidOperationException("Temperatura w kontenerze jest niższa niż wymagana dla produktu ("+requiredTemperature+"°C)");
            }

            LoadWeigth += loadMass;
        }

        public void SetTemperature(float newTemperature)
        {
            if (newTemperature < RequiredTemperature)
            {
                throw new InvalidOperationException("Temperatura nie może być niższa niż wymagana dla produktu ("+RequiredTemperature+"°C)");
            }

            CurrentTemperature = newTemperature;
        }
        
        public void printContainerData()
        {
            string toPrint = "Aktualnie załadowana waga: " + LoadWeigth +
                             " Aktualnie załadowany produkt: "+ProductType+
                             " Aktualna temperatura: "+CurrentTemperature+
                             " Wymagania temperatura: "+RequiredTemperature+
                             " Numer seryjny kontenera: " + SerialNumber +
                             " Maksymalna ładowność: " + MaxLoad +
                             " Waga kontenera: " + ContainerWeigth +
                             " Wysokość: " + Heigth +
                             " Głebkokość: " + Depth;
            Console.WriteLine(toPrint);
        }
    }