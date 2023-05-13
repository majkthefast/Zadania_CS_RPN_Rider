namespace RPN;

public interface IRpnEvaluator
{
    public long Evaluate(string expression);
}

public class Executor
{
    public void Eval(string input) 
    {
        try
        {
            var rpn = new Rpn();  
            int result = rpn.EvalRpn(input);  
            Console.WriteLine(result); 
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}