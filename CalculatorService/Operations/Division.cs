using CalculatorService.Interfaces;
using CalculatorService.Models;

namespace CalculatorService.Operations;

public class Division : OperationBase
{
	public Division(IOperationRequest request) : base(request) { }

	public override IOperationResult Calculate()
	{
		if (Request.B == 0)
		{
			throw new DivideByZeroException("Division by zero is not allowed.");
		}

		var result = Request.A / Request.B;

		return new CalculationResult(Request, result);
	}
}