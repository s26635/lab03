namespace lab03;

public class OverFillDangerousException : Exception
{
    public OverFillDangerousException(int poj)
    {
        Console.Error.WriteLine("Masa ładunku niebezpiecznego nie może przekraczać"+poj+" maksymalnej pojemności!");
    }
}