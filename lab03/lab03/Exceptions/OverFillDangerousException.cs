namespace lab03;

public class OverFillDangerousException : Exception
{
    public OverFillDangerousException()
    {
        Console.Error.WriteLine("Masa ładunku niebezpiecznego nie może przekraczać 50% maksymalnej pojemności!");
    }
}