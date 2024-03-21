namespace lab03.Models;

public class GasContainer : Container
{
    protected float Pressure { set; get; }
    
    public GasContainer(float loadWeigth, float heigth, float containerWeigth, float depth, string serialNumber, float maxLoad) : base(loadWeigth, heigth, containerWeigth, depth, serialNumber, maxLoad)
    {
        
    }

    public void Deload(float deloadMass)
    {
        
    }
}