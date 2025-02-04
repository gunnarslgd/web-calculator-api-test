using CalculatorService.Factories;
using CalculatorService.Interfaces;
using CalculatorService.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Tests;

public class CalculatorTests
{
	private readonly CalculatorService.Services.CalculatorService _calculatorService;

	public CalculatorTests()
	{
		var serviceProvider = new ServiceCollection()
			.AddTransient<IOperationFactory, OperationFactory>()
			.AddTransient<CalculatorService.Services.CalculatorService>()
			.BuildServiceProvider();

		_calculatorService = serviceProvider.GetRequiredService<CalculatorService.Services.CalculatorService>();
	}

	[Theory]
	[InlineData(5, 3, "add", 8)]
	[InlineData(10, 4, "subtract", 6)]
	[InlineData(6, 2, "multiply", 12)]
	[InlineData(8, 2, "divide", 4)]
	public void CalculatorService_Calculate_ReturnsCorrectResult(double a, double b, string operation, double expected)
	{
		var result = _calculatorService.Execute(new CalculationRequest(a, b, operation));
		EqualWithEpsilon(expected, result.Result);
	}

	[Fact]
	public void Division_ByZero_ThrowsException()
	{
		Assert.Throws<DivideByZeroException>(() => _calculatorService.Execute(new CalculationRequest(10, 0, "divide")));
	}

	[Fact]
	public void Invalid_Operation_ThrowsException()
	{
		Assert.Throws<ArgumentException>(() => _calculatorService.Execute(new CalculationRequest(5, 3, "invalid")));
	}

	[Theory]
	[InlineData(0, 5, "add", 5)]
	[InlineData(0, 5, "subtract", -5)]
	[InlineData(0, 0, "multiply", 0)]
	[InlineData(0, 5, "multiply", 0)]
	public void CalculatorService_Calculate_WithZero(double a, double b, string operation, double expected)
	{
		var result = _calculatorService.Execute(new CalculationRequest(a, b, operation));
		EqualWithEpsilon(expected, result.Result);
	}

	[Theory]
	[InlineData(-5, -3, "add", -8)]
	[InlineData(-10, 4, "subtract", -14)]
	[InlineData(-6, 2, "multiply", -12)]
	[InlineData(-8, 2, "divide", -4)]
	public void CalculatorService_Calculate_WithNegativeNumbers(double a, double b, string operation, double expected)
	{
		var result = _calculatorService.Execute(new CalculationRequest(a, b, operation));
		EqualWithEpsilon(expected, result.Result);
	}

	[Theory]
	[InlineData(1.0000001, 1.0000000, "subtract", 0.0000001)]
	[InlineData(0.0000001, 0.0000002, "subtract", -0.0000001)]
	public void CalculatorService_Calculate_WithSmallDifferences(double a, double b, string operation, double expected)
	{
		var result = _calculatorService.Execute(new CalculationRequest(a, b, operation));
		EqualWithEpsilon(expected, result.Result);
	}

	[Theory]
	[InlineData(10, 3, "divide", 3.33333333)] // Test for precision
	public void CalculatorService_Calculate_DivideWithRepeatingDecimal(double a, double b, string operation,
		double expected)
	{
		var result = _calculatorService.Execute(new CalculationRequest(a, b, operation));
		EqualWithEpsilon(expected, result.Result);
	}

	[Theory]
	[InlineData(1E+10, 1, "divide", 1E+10)]
	[InlineData(1E+10, 1E+10, "divide", 1)]
	public void CalculatorService_Calculate_DivideWithLargeNumbers(double a, double b, string operation,
		double expected)
	{
		var result = _calculatorService.Execute(new CalculationRequest(a, b, operation));
		EqualWithEpsilon(expected, result.Result);
	}

	[Fact]
	public void CalculatorService_Calculate_AdditionOverflow_ThrowsOverflowException()
	{
		Assert.Throws<OverflowException>(() => _calculatorService.Execute(new CalculationRequest(double.MaxValue, 1, "add")));
	}

	[Fact]
	public void CalculatorService_Calculate_MultiplicationOverflow_ThrowsOverflowException()
	{
		Assert.Throws<OverflowException>(() => _calculatorService.Execute(new CalculationRequest(double.MaxValue, 2, "multiply")));
	}

	[Fact]
	public void CalculatorService_Calculate_DivideByZero_ThrowsDivideByZeroException()
	{
		Assert.Throws<DivideByZeroException>(() => _calculatorService.Execute(new CalculationRequest(10, 0, "divide")));
	}

	[Fact]
	public void CalculatorService_Calculate_SubtractOverflow_ThrowsOverflowException()
	{
		Assert.Throws<OverflowException>(() => _calculatorService.Execute(new CalculationRequest(double.MinValue, -1, "subtract")));
	}

	[Theory]
	[InlineData(double.MaxValue, double.MaxValue, "divide", 1)]
	public void CalculatorService_Calculate_LargeNumberDivision(double a, double b, string operation, double expected)
	{
		var result = _calculatorService.Execute(new CalculationRequest(a, b, operation));
		EqualWithEpsilon(expected, result.Result); 
	}

	private static void EqualWithEpsilon(double expected, double actual, double epsilon = 1e-8)
	{
		Assert.True(Math.Abs(actual - expected) < epsilon,
			$"Expected {expected}, but got {actual}. Difference exceeds epsilon tolerance of {epsilon}.");
	}
}
