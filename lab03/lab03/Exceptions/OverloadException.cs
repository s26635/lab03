namespace lab03;

public class OverloadException : Exception
{
    public OverloadException(String msg)
    {
        Console.Error.WriteLine(msg);
    }
}