using System.Collections;
using System.Collections.Generic;
using lemure.Collections.Domain;

namespace lemure.Collections.Enumerations;

	public class MyInfinityEnumerator : IEnumerator<Product>
	{
		private readonly List<Product> _products;
		int index = -1;
		public MyInfinityEnumerator(List<Product> products)
		{
			_products = products;
		}

		private Product _current;

		public Product Current => _current;

		object IEnumerator.Current => _current;

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			index++;
			if (index >= _products.Count) return false;

			_current = _products[0];
			return true;
		}

		public void Reset()
		{
			index = -1;
		}
	}
