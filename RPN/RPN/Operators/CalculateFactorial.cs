using RPN.Exceptions;

namespace RPN;

public class FactorialOperation : IMathOperation
{
    public int Execute(Stack<int> stack)
    {
        if (stack.Count == 0)
        {
            throw new NotEnoughNumbersException("Not enough numbers");
        }
        
        var num = stack.Pop();
        int result = 1;
        for (int i = 2; i <= num; i++)
        {
            result *= i;
        }

        return result;
    }
}