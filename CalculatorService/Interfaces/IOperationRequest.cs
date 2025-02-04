namespace CalculatorService.Interfaces
{
	public interface IOperationRequest
	{
		public double A { get; }
		public double B { get; }
		public string Operation { get; }
	}
}
