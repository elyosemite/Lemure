using System;
using System.Collections.Generic;
using System.Linq;
using Lemure.DesignPatterns.Mediator.Mediators;

namespace Lemure.DesignPatterns.Mediator;

	public class Seller
	{
		public Guid SellerIdentifier { get; } = Guid.NewGuid();
		private ICollection<Product> _products { get; } = new List<Product>();
		private MediatorComponent _mediator { get; set; }

		public void ShowProducts()
		{
			foreach (var product in _products)
				Console.WriteLine($"ID: {product.ProductIdentifier} Name: {product.Name} Price: {product.Price}");
		}

		public IEnumerable<Product> GetProducts()
		{
			return _products;
		}

		public IEnumerable<Guid> GetIdentifiersBySeller()
		{
			return _products.Select(o => o.ProductIdentifier).ToList();
		}

		public void AddProduct(Product product) => _products.Add(product);

		public void AddMediator(MediatorComponent mediator) => _mediator = mediator;

		public Product Sell(Guid productIdentifier)
		{
			if (productIdentifier == Guid.Empty) return null;

			var item = _products.Where(product => product.ProductIdentifier == productIdentifier).FirstOrDefault();

			if (item != null) _products.Remove(item);

			return item;
		}
	}
