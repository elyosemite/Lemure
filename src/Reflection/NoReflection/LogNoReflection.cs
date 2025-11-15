using System;
using System.Text;

namespace lemure.Reflection.NoReflection;

	public class LogNoReflection
	{
		public static void ProductLog(Product product)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("Product log");
			builder.AppendLine("Date: " + DateTime.Now);
			builder.AppendLine("Id: " + product.Id);
			builder.AppendLine("Name: " + product.Name);
			builder.AppendLine("Description: " + product.Description);
			builder.AppendLine("Stock: " + product.Stock);
			LogPrint(builder.ToString());
		}

		public static void OrdersLog(Order order)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("Order log");
			builder.AppendLine("Date: " + DateTime.Now);
			builder.AppendLine("Id: " + order.Id);
			builder.AppendLine("CustumerId: " + order.CustumerId);
			builder.AppendLine("OrderDate: " + order.OrderDate);
			LogPrint(builder.ToString());
		}

		public static void CustomerLog(Customer customer)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("Order log");
			builder.AppendLine("Date: " + DateTime.Now);
			builder.AppendLine("Id: " + customer.Id);
			builder.AppendLine("Name: " + customer.Name);
			builder.AppendLine("Address: " + customer.Address);
			LogPrint(builder.ToString());
		}

		public static void LogPrint(string text)
		{
			Console.WriteLine(text);
		}
	}
