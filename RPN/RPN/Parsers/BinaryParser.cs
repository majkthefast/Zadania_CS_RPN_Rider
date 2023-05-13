namespace RPN.Parsers
{
    public class BinaryParser : INumberParser
    {
        public bool TryParse(string token, out int number)
        {
            if (token.StartsWith("0b") || token.StartsWith("0B")) // sprawdź czy token zaczyna się od "0b" lub "0B"
            {
                token = token.Substring(2); // usuń prefiks "0b" lub "0B"
                try
                {
                    number = Convert.ToInt32(token, 2); // zamień token na liczbę w systemie dziesiętnym
                    return true;
                }
                catch (Exception)
                {
                    number = 0;
                    return false;
                }
            }
            else
            {
                number = 0;
                return false;
            }
        }
    }
}