namespace Lemure.DesignPatterns.ChainOfResponsability;

	public abstract class BaseBudgetHandler
	{
		protected BaseBudgetHandler NextHandler = null;

		public BaseBudgetHandler SetNexthandler(BaseBudgetHandler handler)
		{
			NextHandler = handler;
			return NextHandler;
		}

		public virtual CustomerBudget Handle(CustomerBudget budget)
		{
			if (NextHandler is not null)
				NextHandler.Handle(budget);
			return budget;
		}
	}