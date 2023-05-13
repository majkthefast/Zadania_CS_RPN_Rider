namespace RPN.Parsers;

public class DecimalParser : INumberParser
{
    public bool TryParse(string token, out int number) // zamień token na liczbę w systemie dziesiętnym
    {
        try
        {
            number = Convert.ToInt32(token); 
            return true;
        }
        catch (Exception)
        {
            number = 0;
            return false;
        }
    }
}