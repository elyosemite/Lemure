namespace Lemure.DesignPatterns.ChainOfResponsability;

	public class CustomerBudget
	{
		public bool Approved { get; set; } = false;
		public int TotalPrice;

		public CustomerBudget(int totalPrice)
		{
			TotalPrice = totalPrice;
		}
	}