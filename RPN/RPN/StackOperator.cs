namespace RPN;

internal class StackOperator
{
    private static Executor _executor = new Executor();
    private static void Main()
    {
        _executor.Eval("2 2 +"); 
        _executor.Eval("2 2 2 + +"); 
        _executor.Eval("2 2 2 + + 2 -"); 
        _executor.Eval("2 2 -"); 
        _executor.Eval("2 2 2 2 + - / 2 * 2 2 2 + + -");
        _executor.Eval("3 !");
        _executor.Eval("1 2 3 4 5 6 7 8 9 10 avg");
        _executor.Eval("0x1F4 0B111110011 -"); 
    }
}