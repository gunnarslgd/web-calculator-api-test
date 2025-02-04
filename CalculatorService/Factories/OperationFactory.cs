using CalculatorService.enums;
using CalculatorService.Interfaces;
using CalculatorService.Operations;

namespace CalculatorService.Factories;

public class OperationFactory : IOperationFactory
{
	private readonly Dictionary<string, Func<IOperationRequest, IOperation>> _operations =
		new()
		{
			{ nameof(OperationType.Add).ToLower(), request => new Addition(request) },
			{ nameof(OperationType.Subtract).ToLower(), request => new Subtraction(request) },
			{ nameof(OperationType.Multiply).ToLower(), request => new Multiplication(request) },
			{ nameof(OperationType.Divide).ToLower(), request => new Division(request) }
		};

	public IOperation GetOperation(IOperationRequest request)
	{
		if (_operations.TryGetValue(request.Operation.ToLower(), out var toOperation))
		{
			return toOperation(request);
		}

		throw new ArgumentException($"Operation {request.Operation} is not supported.");
	}
}