using RPN.Exceptions;

namespace RPN;

public class CalculateSubstract : IMathOperation
{
    public int Execute(Stack<int> stack)
    {
        if (stack.Count < 2)
        {
            throw new NotEnoughNumbersException("Not enough numbers");
        }
        
        var num1 = stack.Pop();
        var num2 = stack.Pop();

        return num2 - num1;
    }
}