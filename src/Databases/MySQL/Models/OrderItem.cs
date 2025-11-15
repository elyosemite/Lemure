using System;
using System.ComponentModel.DataAnnotations;

namespace Lemure.Databases.MySQL.Models;

	public class OrderItem
	{
		[Key]
		public int Id { get; private set; } = new Random().Next(100, 10000);
		public string Name { get; private set; }
		public DateTime CreatedAt { get; private set; }
		public string Description { get; private set; }

		public int OrderId { get; }

		public OrderItem(string name, DateTime createdAt, string description, int orderId)
		{
			Name = name;
			CreatedAt = createdAt;
			Description = description;
			OrderId = orderId;
		}
	}
