using RPN.Exceptions;

namespace RPN;

public class CalculateAverage : IMathOperation
{
    public int Execute(Stack<int> stack)
    {
        var numbers = new List<int>();

        if (stack.Count < 2) 
        {
            throw new NotEnoughNumbersException("Not enough numbers"); 
        }
        
        while (stack.Count > 0) // 1 2 3 4 5 6 7 8 9 10
        {
            int number = stack.Pop(); // 10
            numbers.Add(number); // 10
        }
        
        int sum = numbers.Sum(); // 55
        int count = numbers.Count;  // 10
        int average = count == 0 ? 0 : sum / count; // 5
        
        return average; // 5
    }
}