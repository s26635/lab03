namespace lab03;

public class InvalidProductException : Exception
{
    public InvalidProductException(String message)
        : base(message)
    {
        Console.Error.WriteLine(message);
    }
}