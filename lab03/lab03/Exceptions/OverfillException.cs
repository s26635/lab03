namespace lab03;

public class OverfillException : Exception
{
    public OverfillException(string msg)
    {
        Console.Error.WriteLine(msg);
    }


}