using System;

namespace Lemure.DesignPatterns.ChainOfResponsability;

	public class ManagerBudgetHandler : BaseBudgetHandler
	{
		public override CustomerBudget Handle(CustomerBudget budget)
		{
			if (budget.TotalPrice <= 5000)
			{
				Console.WriteLine("The Manager has handled the budget.");
				budget.Approved = true;
				return budget;
			}

			return base.Handle(budget);
		}
	}
