namespace Lemure.DesignPatterns.ChainOfResponsability;

	public class MainChainOfResponsability
	{
		public static void Run()
		{
			var customerBudgets = new CustomerBudget[]
			{
				new CustomerBudget(10),
				new CustomerBudget(1000),
				new CustomerBudget(2000),
				new CustomerBudget(10000),
				new CustomerBudget(51000),
				new CustomerBudget(100000)
			};

			var seller = new SellerBudgetHandler();
			seller
				.SetNexthandler(new ManagerBudgetHandler())
				.SetNexthandler(new DirectorBudgetHandler())
				.SetNexthandler(new CEOBudgetHandler());

			foreach (var budget in customerBudgets)
			{
				seller.Handle(budget);
			}
		}
	}
