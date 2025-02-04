using CalculatorService.Interfaces;
using CalculatorService.Models;

namespace CalculatorService.Operations;

public class Addition : OperationBase
{
	public Addition(IOperationRequest request) : base(request) { }

	public override IOperationResult Calculate()
	{
		return new CalculationResult(Request, Request.A + Request.B);
	}
}