using CalculatorService.Interfaces;

namespace CalculatorService.Models;

public class CalculationRequest : IOperationRequest
{
	public double A { get; set; }
	public double B { get; set; }
	public string Operation { get; set; }

	public CalculationRequest(double a, double b, string operation)
	{
		A = a;
		B = b;
		Operation = operation;
	}
}