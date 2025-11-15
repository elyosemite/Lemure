using System;
using System.Collections.Generic;
using Lemure.DesignPatterns.Mediator.Mediators;

namespace Lemure.DesignPatterns.Mediator;

	public class Buyer
	{
		public Guid BuyerIdentifier { get; } = Guid.NewGuid();
		private MediatorComponent _mediator { get; set; }

		public Buyer(MediatorComponent mediator)
		{
			_mediator = mediator;
		}

		public void ShowProductsBySeller(Guid sellerIdentifier)
		{
			_mediator.ShowProducts(sellerIdentifier);
		}

		public void Buy(IEnumerable<Guid> productIdentifiers)
		{
			foreach (var identifier in productIdentifiers)
				Console.WriteLine($"You just buy: {_mediator.Buy(identifier)}");
		}
	}
