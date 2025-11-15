using System;
using lemure.interfaces;

namespace lemure.services;

	class MongoDbDatabaseService : IDatabase
	{
		public void delete()
		{
			Console.WriteLine("MongoDB...");
			Console.WriteLine("Deleting 1 row");
		}

		public void insert()
		{
			Console.WriteLine("MongoDB...");
			Console.WriteLine("Inserting 1 row");
		}

		public void select()
		{
			Console.WriteLine("MongoDB...");
			Console.WriteLine("Selecting 1 row");
		}

		public void update()
		{
			Console.WriteLine("MongoDB...");
			Console.WriteLine("Updating 1 row");
		}
	}
