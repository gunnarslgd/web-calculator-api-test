using CalculatorService.Factories;
using CalculatorService.Interfaces;

namespace CalculatorService.Services;

public static class OperationServiceRegistration
{
	public static void AddOperations(this IServiceCollection services)
	{
		services.AddSingleton<IOperationFactory, OperationFactory>();
		services.AddSingleton<CalculatorService>();
	}
}