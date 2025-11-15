using System;

namespace Lemure.DesignPatterns.ChainOfResponsability;

	public class DirectorBudgetHandler : BaseBudgetHandler
	{
		public override CustomerBudget Handle(CustomerBudget budget)
		{
			if (budget.TotalPrice <= 50000)
			{
				Console.WriteLine("The Director has handled the budget.");
				budget.Approved = true;
				return budget;
			}

			return base.Handle(budget);
		}
	}
