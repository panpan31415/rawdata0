﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using DAL.ReadOnly;

namespace DAL
{
	public class QuestionMapper : DataMapper<Question>
	{
		public UserMapper UserMapper { get; set; }


		public QuestionMapper(string connectionString) : base(connectionString)
		{
			TableName = "post";
			Attributes = new string[] { "body", "score", "title", "creationDate", "ownerUserId" , "answerCount" };
			UserMapper = new UserMapper(connectionString);
        }

		public override Question Map(MySqlDataReader reader)
		{
			if (reader.HasRows)
			{
				int q_id, q_score, q_owner_id;
				string q_body, q_title;
				string q_date;
				int answerCount;

				if (!reader.IsDBNull(0)) { q_id = reader.GetInt32(0); }
				else { q_id = 0; }
				if (!reader.IsDBNull(1)) { q_body = reader.GetString(1); }
				else { q_body = "unknown"; }
				if (!reader.IsDBNull(2)) { q_score = reader.GetInt32(2); }
				else { q_score = 0; }
				if (!reader.IsDBNull(3)) { q_title = reader.GetString(3); }
				else { q_title = "unknown"; }
				if (!reader.IsDBNull(4)) { q_date = reader.GetString(4); }
				else { q_date = "unknown"; }
				if (!reader.IsDBNull(5)) { q_owner_id = reader.GetInt32(5); }
				else { q_owner_id = 0; }
				if (!reader.IsDBNull(6)) { answerCount = reader.GetInt32(6); }
				else { answerCount = 0; }

				var question = new Question
				{
					Id = q_id,
					Body = q_body,
					Score = q_score,
					Title = q_title,
					CreationDate = q_date,
					OwnerId = q_owner_id,
                    answerCount=answerCount
                };
				return question;
			}
			return null;
		}
		//private string FetchOwnername(int id)
		//{
		//	using (var connection = new MySqlConnection(ConnectionString))
		//	{
		//		connection.Open();
		//		var cmd = new MySqlCommand();
		//		cmd.Connection = connection;
		//		cmd.CommandText = "select displayName from user where  id= @ID";
		//		cmd.Parameters.AddWithValue("@ID", id);
		//		using (var reader = cmd.ExecuteReader())
		//		{
		//			while (reader.Read())
		//			{
		//				string uname = reader.GetString(0);
		//				return uname;
		//			}
		//			return "unknown";
		//		}
		//	}
		//}

	
	}
}

