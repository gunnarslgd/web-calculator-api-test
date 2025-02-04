using CalculatorService.Interfaces;

namespace CalculatorService.Operations;

public abstract class OperationBase : IOperation
{
	protected OperationBase(IOperationRequest request)
	{
		Request = request;
	}

	public IOperationRequest Request { get; }
	public abstract IOperationResult Calculate();
}