namespace CalculatorService.Interfaces;

public interface IOperationFactory
{
	IOperation GetOperation(IOperationRequest request);
}