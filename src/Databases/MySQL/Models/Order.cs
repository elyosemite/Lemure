using System;
using System.ComponentModel.DataAnnotations;

namespace Lemure.Databases.MySQL.Models;

	public class Order
	{
		[Key]
		public int Id { get; private set; } = new Random().Next(100, 10000);
		public string Name { get; private set; }
		public DateTime CreatedAt { get; private set; }
		public string Description { get; private set; }

		public Order(string name, DateTime createdAt, string description)
		{
			Name = name;
			CreatedAt = createdAt;
			Description = description;
		}
	}
