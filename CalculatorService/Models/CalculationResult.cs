using CalculatorService.Interfaces;

namespace CalculatorService.Models;

public class CalculationResult : IOperationRequest, IOperationResult
{
	public CalculationResult(IOperationRequest request, double result)
	{
		// Perform the overflow and NaN checks
		CheckForOverflow(result, request.Operation);

		Result = result;
		Operation = request.Operation;
		A = request.A;
		B = request.B;
	}

	public double A { get; }
	public double B { get; }
	public string Operation { get; }
	public double Result { get; }

	private static void CheckForOverflow(double result, string operation)
	{
		if (double.IsInfinity(result) || result is >= double.MaxValue or <= double.MinValue)
		{
			throw new OverflowException($"Arithmetic overflow occurred during {operation}.");
		}

		if (double.IsNaN(result))
		{
			throw new ArithmeticException($"Invalid arithmetic result (NaN) during {operation}.");
		}
	}
}