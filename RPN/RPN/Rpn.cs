using RPN.Exceptions;
using RPN.Parsers;

namespace RPN;

public sealed class Rpn
{
    private readonly Stack<int> _tokensStack = new Stack<int>(); // stos
    private readonly Dictionary<string, IMathOperation> _math = new(); // słownik
    private readonly IEnumerable<INumberParser> _parsers = new List<INumberParser> 
    {
        new DecimalParser(), 
        new BinaryParser(),
        new HexParser()
    };


    public int EvalRpn(string input)
    {
        _math["+"] = new CalculateSum();
        _math["-"] = new CalculateSubstract();
        _math["*"] = new CalculateMultiply();
        _math["/"] = new CalculateDivide();
        _math["!"] = new FactorialOperation();
        _math["%"] = new CalculateModulo();
        _math["avg"] = new CalculateAverage();

        var splitInput = input.Split(' '); // dzieli stringa na tablicę stringów
        
        foreach (var op in splitInput) // dla każdego elementu tablicy
        {
            bool parsedSuccessfully = false;
            foreach (var numberParser in _parsers)
            {
                if (numberParser.TryParse(op, out var number)) // jeśli udało się sparsować
                {
                    _tokensStack.Push(number); // dodaj liczbę na stos
                    parsedSuccessfully = true; 
                    break;
                }
            }

            if (parsedSuccessfully) continue;
            
            if (!_math.ContainsKey(op)) // jeśli nie ma takiego klucza w słowniku
                throw new UnexpectedTokenException($"Unexpected token: {op}"); // wyrzuć wyjątek
            var operation = _math[op]; // pobierz wartość ze słownika

            var opResult = operation.Execute(_tokensStack);  // wykonaj operację
            _tokensStack.Push(opResult); 
        }

        var result = _tokensStack.Pop(); // zdejmij ze stosu
        if (_tokensStack.Count == 0) // jeśli stos jest pusty
        {
            return result;
        }

        throw new InvalidOperationException(); // wyrzuć wyjątek
    }
}