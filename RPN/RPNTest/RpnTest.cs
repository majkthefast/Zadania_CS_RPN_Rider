using RPN.Exceptions;

namespace RPNTest;

[TestFixture]
public class RpnTest {
    private Rpn _sut;
    [SetUp]
    public void Setup() {
        _sut = new Rpn();
    }
    [Test]
    public void CheckIfTestWorks() {
        Assert.Pass();
    }

    [Test]
    public void CheckIfCanCreateSut() {
        Assert.That(_sut, Is.Not.Null);
    }

    [Test]
    public void SingleDigitOneInputOneReturn() {
        var result = _sut.EvalRpn("1");

        Assert.That(result, Is.EqualTo(1));

    }
    [Test]
    public void SingleDigitOtherThenOneInputNumberReturn() {
        var result = _sut.EvalRpn("2");

        Assert.That(result, Is.EqualTo(2));

    }
    [Test]
    public void TwoDigitsNumberInputNumberReturn() {
        var result = _sut.EvalRpn("12");

        Assert.That(result, Is.EqualTo(12));

    }
    [Test]
    public void TwoNumbersGivenWithoutOperator_ThrowsExcepton() {
        Assert.Throws<InvalidOperationException>(() => _sut.EvalRpn("1 2"));

    }
    [Test]
    public void OperatorPlus_AddingTwoNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("1 2 +");

        Assert.That(result, Is.EqualTo(3));
    }
    [Test]
    public void OperatorTimes_AddingTwoNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("2 2 *");

        Assert.That(result, Is.EqualTo(4));
    }
    [Test]
    public void OperatorMinus_SubstractingTwoNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("1 2 -");

        Assert.That(result, Is.EqualTo(-1));
    }
    [Test]
    public void ComplexExpression() {
        var result = _sut.EvalRpn("15 7 1 1 + - / 3 * 2 1 1 + + -");
        Assert.That(result, Is.EqualTo(5));
    }
    
    [Test]
    public void OperatorTimes_MultiplyingOneNumber_ThrowsException() {
        Assert.Throws<NotEnoughNumbersException>(() => _sut.EvalRpn("2 *"));
    }
    
    [Test]
    public void OperatorDivide_DividingOneNumber_ThrowsException() {
        Assert.Throws<NotEnoughNumbersException>(() => _sut.EvalRpn("2 /"));
    }
    
    [Test]
    public void OperatorPlus_AddingThreeNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("1 2 3 + +");

        Assert.That(result, Is.EqualTo(6));
    }
    
    [Test]
    public void OperatorTimes_MultiplyingThreeNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("1 2 3 * *");

        Assert.That(result, Is.EqualTo(6));
    }
    
    [Test]
    public void OperatorDivide_DividingThreeNumbers_ThrowsException() {
        Assert.Throws<DivideByZeroException>(() => _sut.EvalRpn("1 2 3 / /"));
    }

    [Test]
    public void OperatorMinus_SubstractingThreeNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("2 2 2 - -");

        Assert.That(result, Is.EqualTo(2));
    }
    
    [Test]
    public void OperatorPlus_AddingFourNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("2 2 2 2 + + +");

        Assert.That(result, Is.EqualTo(8));
    }

    [Test]
    public void OperatorTimes_MultiplyingFourNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("1 2 3 4 * * *");

        Assert.That(result, Is.EqualTo(24));
    }
    
    [Test]
    public void OperatorModulo_ModuloOfOneNumber_ThrowsException() {
        Assert.Throws<NotEnoughNumbersException>(() => _sut.EvalRpn("2 %"));
    }

    
    [Test]
    public void Multiplication_MultiplicationOfTwoNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("2 2 *");

        Assert.That(result, Is.EqualTo(4));
    }
    
    [Test]
    public void Multiplication_MultiplicationOfThreeNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("2 2 2 * *");

        Assert.That(result, Is.EqualTo(8));
    }
    
    [Test]
    public void Multiplication_MultiplicationOfTwoNumbersWithOtherOperators_ReturnCorrectResult() {
        var result = _sut.EvalRpn("2 2 * 2 +");

        Assert.That(result, Is.EqualTo(6));
    }
    
    [Test]
    public void Multiplication_MultiplicationOfFourNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("2 2 2 2 * * *");

        Assert.That(result, Is.EqualTo(16));
    }
    
    [Test]
    public void OperatorFactorial_FactorialOfOneNumber_ReturnCorrectResult() {
        var result = _sut.EvalRpn("3 !");

        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void OperatorModulo_ModuloOfTwoNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("3 2 %");

        Assert.That(result, Is.EqualTo(1));
    }
    
    [Test]
    public void BinaryNumberParser_BinaryNumber_ReturnCorrectResult() {
        var result = _sut.EvalRpn("0B111110100");

        Assert.That(result, Is.EqualTo(500));
    }
    
    [Test]
    
    public void BinaryNumberParser_BinaryNumberWithOperator_ReturnCorrectResult() {
        var result = _sut.EvalRpn("0B111110100 1 +");

        Assert.That(result, Is.EqualTo(501));
    }
    
    [Test]
    
    public void BinaryNumberParser_BinaryNumbersWithOperatorAndSpaces_ReturnCorrectResult() {
        var result = _sut.EvalRpn("0B111110100 1 + 0B110 +");

        Assert.That(result, Is.EqualTo(507));
    }

    [Test]
    public void HexNumberParser_HexNumber_ReturnCorrectResult() {
        var result = _sut.EvalRpn("0XFF");

        Assert.That(result, Is.EqualTo(255));
    }
    
    [Test]
    public void HexNumberParser_HexNumberWithOperator_ReturnCorrectResult() {
        var result = _sut.EvalRpn("0XFF 1 +");

        Assert.That(result, Is.EqualTo(256));
    }
    
    [Test]
    public void HexNumberParser_HexNumberWithOperatorAndSpaces_ReturnCorrectResult() {
        var result = _sut.EvalRpn("0XFF 1 +");

        Assert.That(result, Is.EqualTo(256));
    }

    [Test]
    public void DecimalNumberParser_DecimalNumber_ReturnCorrectResult() {
        var result = _sut.EvalRpn("222");

        Assert.That(result, Is.EqualTo(222));
    }
    
    [Test]
    public void DecimalNumberParser_DecimalNumberWithOperator_ReturnCorrectResult() {
        var result = _sut.EvalRpn("222 1 +");

        Assert.That(result, Is.EqualTo(223));
    }

    [Test]
    public void Average_AverageOfTwoNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("2 2 avg");

        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void Average_AverageOfFourNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("2 2 2 2 avg");

        Assert.That(result, Is.EqualTo(2));
    }
    
    [Test]
    public void Average_OnlyAverageOperator_ThrowsException() {
        Assert.Throws<NotEnoughNumbersException>(() => _sut.EvalRpn("avg"));
    }
    
    [Test]
    public void UnexpectedToken_UnexpectedToken_ThrowsException() {
        Assert.Throws<UnexpectedTokenException>(() => _sut.EvalRpn("2 2 2 2 avg a"));
    }

    [Test]
    public void Multiplication_OnlyMultiplicationOperator_ThrowsException() {
        Assert.Throws<NotEnoughNumbersException>(() => _sut.EvalRpn("+"));
    }
}