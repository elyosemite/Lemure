using System;
using System.Collections.Generic;
using System.Linq;

namespace Lemure.DesignPatterns.Mediator.Mediators;

	public class MediatorComponent
	{
		private ICollection<Seller> _sellers { get; } = new List<Seller>();

		public void AddSellers(IEnumerable<Seller> sellers)
		{
			foreach (var seller in sellers)
				_sellers.Add(seller);
		}

		public void AddSeller(Seller seller)
		{
			_sellers.Add(seller);
		}

		public Product Buy(Guid productIdentifier)
		{
			Product product = null;

			foreach (var seller in _sellers)
			{
				product = seller.Sell(productIdentifier);

				if (product is not null)
					return product;
			}

			Console.WriteLine("Product doesn't exist.");

			return product;
		}

		public void ShowProducts(Guid sellerIdentifier)
		{
			if (sellerIdentifier == Guid.Empty) Console.WriteLine("Seller does not sign up.");

			Seller seller = _sellers.Where(o => o.SellerIdentifier == sellerIdentifier).FirstOrDefault();
			seller.ShowProducts();
		}

		public IEnumerable<Product> GetProductsBySeller(Guid sellerIdentifier)
		{
			Seller seller = _sellers.Where(o => o.SellerIdentifier == sellerIdentifier).FirstOrDefault();
			return seller.GetProducts();
		}

		public ICollection<Guid> ShowSellers()
		{
			var identifiers = new List<Guid>();

			foreach (var item in _sellers)
			{
				Console.WriteLine(item.SellerIdentifier);
				identifiers.Add(item.SellerIdentifier);
			}

			return identifiers;
		}
	}
