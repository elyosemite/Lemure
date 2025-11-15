using System.Collections;
using System.Collections.Generic;
using lemure.Collections.Domain;

namespace lemure.Collections.Enumerations;

	public class MyInfinityEnumerable : IEnumerable<Product>
	{
		private readonly List<Product> _products;

		public MyInfinityEnumerable(List<Product> products)
		{
			_products = products;
		}

		public IEnumerator<Product> GetEnumerator()
			=> new MyInfinityEnumerator(_products);

		IEnumerator IEnumerable.GetEnumerator()
			=> new MyInfinityEnumerator(_products);
	}
