namespace lab03;

public class OverfillException : Exception
{
    public OverfillException()
    {
        Console.Error.WriteLine("Masa ładunku przekracza maksymalną ładowność!");
    }
}