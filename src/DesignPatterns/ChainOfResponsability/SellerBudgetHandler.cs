using System;

namespace Lemure.DesignPatterns.ChainOfResponsability;

	public class SellerBudgetHandler : BaseBudgetHandler
	{
		public override CustomerBudget Handle(CustomerBudget budget)
		{
			if (budget.TotalPrice <= 1000)
			{
				Console.WriteLine("The Seller has handled the budget.");
				budget.Approved = true;
				return budget;
			}

			return base.Handle(budget);
		}
	}
