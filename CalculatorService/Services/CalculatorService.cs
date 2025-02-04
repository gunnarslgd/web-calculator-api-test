using CalculatorService.Interfaces;

namespace CalculatorService.Services;

public class CalculatorService
{
	private readonly IOperationFactory _factory;

	public CalculatorService(IOperationFactory factory)
	{
		_factory = factory;
	}

	public IOperationResult Execute(IOperationRequest request)
	{
		var operation = _factory.GetOperation(request);
		return operation.Calculate();
	}
}