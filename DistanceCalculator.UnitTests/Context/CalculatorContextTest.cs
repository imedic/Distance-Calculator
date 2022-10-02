using DistanceCalculator.Core.Contracts;
using DistanceCalculator.Core.Enums;
using DistanceCalculator.Core.Factories;
using DistanceCalculator.Core.ValueObjects;
using Moq;

namespace DistanceCalculator.UnitTests.Context;

public class CalculatorContextTest
{
    [Fact]
    public void SetFormula_DoesNotThrow()
    {
        var mock = new Mock<ICalculator>();
        mock.Setup(p => p.Formula).Returns(Formula.Haversine);

        List<ICalculator> mockCalculators = new List<ICalculator>();
        
        mockCalculators.Add(mock.Object);

        var context = new CalculatorContext(mockCalculators);

        var exception = Record.Exception(() => context.SetFormula(Formula.Haversine));

        Assert.Null(exception);
    }

    [Fact]
    public void SetFormula_InvalidSetup_Throws()
    {
        var mock = new Mock<ICalculator>();

        List<ICalculator> mockCalculators = new List<ICalculator>();

        mockCalculators.Add(mock.Object);

        var context = new CalculatorContext(mockCalculators);

        var exception = Record.Exception(() => context.SetFormula(Formula.Haversine));

        Assert.NotNull(exception);
    }

    [Fact]
    public void Calculate_CorrectSetup_ReturnsCorrectData()
    {
        double expected = 5;
        var mock = new Mock<ICalculator>();
        mock.Setup(p => p.Formula).Returns(Formula.Haversine);
        mock.Setup(p => p.Calculate(It.IsAny<Coordinates>(), It.IsAny<Coordinates>(), It.IsAny<double>())).Returns(expected);

        List<ICalculator> mockCalculators = new List<ICalculator>();

        mockCalculators.Add(mock.Object);

        var context = new CalculatorContext(mockCalculators);

        context.SetFormula(Formula.Haversine);
        var result = context.Calculate(new Coordinates(10, 10), new Coordinates(10, 10), 10);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Calculate_InvalidSetup_Throws()
    {
        double expected = 5;
        var mock = new Mock<ICalculator>();
        mock.Setup(p => p.Formula).Returns(Formula.Haversine);
        mock.Setup(p => p.Calculate(It.IsAny<Coordinates>(), It.IsAny<Coordinates>(), It.IsAny<double>())).Returns(expected);

        List<ICalculator> mockCalculators = new List<ICalculator>();

        mockCalculators.Add(mock.Object);

        var context = new CalculatorContext(mockCalculators);

        var exception = Record.Exception(() => context.Calculate(new Coordinates(10, 10), new Coordinates(10, 10), 10));

        Assert.NotNull(exception);
    }
}
