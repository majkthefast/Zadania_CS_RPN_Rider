namespace RPN.Parsers
{
    public class HexParser : INumberParser
    {
        public bool TryParse(string token, out int number) // zamień token na liczbę w systemie szesnastkowym
        {
            if (token.StartsWith("0x") || token.StartsWith("0X")) // sprawdź czy token zaczyna się od "0x" lub "0X"
            {
                token = token.Substring(2); // usuń prefiks "0x" lub "0X"
                try
                {
                    number = Convert.ToInt32(token, 16); 
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