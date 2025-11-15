using System;
using System.Collections.Generic;

namespace lemure.LazyInitialization;

	class LazyInit
	{
		public void Load()
		{
			Lazy<List<Order>> _orders = new Lazy<List<Order>>(() => new Order().create(3));
			Console.WriteLine(_orders.Value.Count);
		}
	}
