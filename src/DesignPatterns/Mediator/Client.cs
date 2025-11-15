using System.Linq;
using Lemure.DesignPatterns.Mediator.Mediators;

namespace Lemure.DesignPatterns.Mediator;

	public class Client
	{
		public static void Run()
		{
			var mediator = new MediatorComponent();
			var buyer = new Buyer(mediator);

			#region Sellers
			var seller01 = new Seller();
			seller01.AddProduct(new Product("Camiseta 01", 49.99m));
			seller01.AddProduct(new Product("Camiseta 02", 49.99m));
			seller01.AddProduct(new Product("Camiseta 03", 49.99m));
			seller01.AddProduct(new Product("Camiseta 04", 49.99m));

			var seller02 = new Seller();
			seller02.AddProduct(new Product("Computador 01", 4900.99m));
			seller02.AddProduct(new Product("Computador 02", 4900.99m));
			seller02.AddProduct(new Product("Computador 03", 4900.99m));
			seller02.AddProduct(new Product("Computador 04", 4900.99m));

			var seller03 = new Seller();
			seller03.AddProduct(new Product("Livro 01", 490.99m));
			seller03.AddProduct(new Product("Livro 02", 490.99m));
			seller03.AddProduct(new Product("Livro 03", 490.99m));
			seller03.AddProduct(new Product("Livro 04", 490.99m));
			#endregion

			mediator.AddSeller(seller01);
			mediator.AddSeller(seller02);
			mediator.AddSeller(seller03);

			buyer.ShowProductsBySeller(seller01.SellerIdentifier);

			var identifiers = seller01.GetProducts().Select(o => o.ProductIdentifier).Take(2);
			buyer.Buy(identifiers);
			buyer.ShowProductsBySeller(seller01.SellerIdentifier);
		}
	}
