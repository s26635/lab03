namespace lab03.Models;

 public class RefrigeratedContainer : Container
    {
        public string ProductType { get; }
        public float RequiredTemperature { get; }
        public float CurrentTemperature { get; private set; }

        public RefrigeratedContainer(float loadWeight, float height, float containerWeight, float depth, string serialNumber, float maxLoad, string productType, float requiredTemperature)
            : base(loadWeight, height, containerWeight, depth, serialNumber, maxLoad)
        {
            ProductType = productType;
            RequiredTemperature = requiredTemperature;
            CurrentTemperature = requiredTemperature; 
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
    }