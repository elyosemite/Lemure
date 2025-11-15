using System;

namespace Lemure.DesignPatterns.ChainOfResponsability;

	public class CEOBudgetHandler : BaseBudgetHandler
	{
		public override CustomerBudget Handle(CustomerBudget budget)
		{
			budget.Approved = true;
			Console.WriteLine("The CEO has handled the budget;");
			return budget;
		}
	}
