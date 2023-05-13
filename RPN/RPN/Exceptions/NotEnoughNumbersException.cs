namespace RPN.Exceptions;

public class NotEnoughNumbersException : Exception
{
    public NotEnoughNumbersException(string message) : base(message)
    {
    }
}