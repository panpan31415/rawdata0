﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public abstract class DataMapper<T> : IDataMapper<T> where T : class, IIdentityField
	{
		public string ConnectionString { get; set; }
		public string TableName { get; set; }
		public string[] Attributes { get; set; }
		public DataMapper(string connectionString)
		{
			ConnectionString = connectionString;
		}

		//public T GetById(int id)
		//{
		//	var sql = string.Format("SELECT ID, {0} from {1} WHERE ID = @ID", AttributeList, TableName);
		//	using (var connection = new MySqlConnection(ConnectionString))
		//	{
		//		connection.Open();
		//		using (var cmd = new MySqlCommand(sql))
		//		{
		//			cmd.Parameters.AddWithValue("@ID", id);
		//			cmd.Connection = connection;
		//			using (var reader = cmd.ExecuteReader())
		//			{
		//				reader.Read();
		//				QueryResultNumber = 1;
		//				return Map(reader);
		//			}
		//		}
		//	}
			
  //      }
		public IEnumerable<T> Query(MySqlCommand command)
		{
			using (var connection = new MySqlConnection(ConnectionString))
			{
				connection.Open();
				command.Connection = connection;
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						var element = Map(reader);
						if (element == null)
						{
							yield break;
						}
						yield return element;
					}
				}
			}
		}
		public int QueryCount(MySqlCommand command)
		{
			using (var connection = new MySqlConnection(ConnectionString))
			{
				connection.Open();
				command.Connection = connection;
				using (var reader = command.ExecuteReader())
				{
					if (reader.FieldCount > 1)
					{
						throw new Exception("Used wrong sql command, only 'slect count(col) from table' allowed");
					}
					else {
						reader.Read();
						return reader.GetInt32(0);
					}
				}
			}
		}


		public abstract T Map(MySqlDataReader reader);

		protected string AttributeList { get { return string.Join(", ", Attributes); } }
		protected string DecoratedAttributeList(Func<string, string> selector)
		{
			return string.Join(", ", Attributes.Select(selector));
		}
	}
}
