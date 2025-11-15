using System;
using System.Linq;
using Lemure.Databases.MySQL.Contexts;
using Lemure.Databases.MySQL.Models;
using Microsoft.EntityFrameworkCore;

namespace Lemure.Databases.MySQL;

	public class Client
	{
		public void Run()
		{
			using (var context = new Context())
			{
				var order = new Order("Pedido ", DateTime.Now, "Compras escolares");

				var orderItem1 = new OrderItem("Caderno 200 folhas", DateTime.Now, "bla bla 01", order.Id);
				var orderItem2 = new OrderItem("Lápis Vermelho", DateTime.Now, "bla bla 02", order.Id);

				context.Order.Add(order);
				context.OrderItem.Add(orderItem1);
				context.OrderItem.Add(orderItem2);

				context.SaveChanges();
			}
		}

		public void Show()
		{
			using (var context = new Context())
			{
				int orderIdentifier = 4298;
				var orderItens = context.OrderItem.Include(m => m.OrderId == orderIdentifier);

				var result2 = context
					.Order
					.AsNoTracking()
					.Join(context.OrderItem,
					order => order.Id,
					orderItem => orderItem.OrderId,
					(order, orderItem) => new { Order = order, OrderItem = orderItem });

				foreach (var item in result2)
					Console.WriteLine($"Id:{item.Order.Id}-{item.Order.Name} - {item.OrderItem.Name}:Foreign Key[{item.OrderItem.OrderId}]");

				context.SaveChanges();
			}
		}
	}
