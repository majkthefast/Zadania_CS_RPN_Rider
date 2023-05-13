namespace RPN;

public interface INumberParser
{
    bool TryParse(string token, out int number);
}