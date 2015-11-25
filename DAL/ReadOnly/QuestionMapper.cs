using System;
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
		public QuestionMapper(string connectionString) : base(connectionString)
		{
			TableName = "post";
			Attributes = new string[] { "body", "score", "title", "creationDate", "ownerUserId" };
		}

		//public override Question GetById(int id)
		//{
			 
		//}

		public override Question Map(MySqlDataReader reader)
		{
			if (reader.HasRows && reader.Read())
			{
				int q_oid, q_id, q_score;
				string q_body, q_title;
				DateTime q_date;

				if (!reader.IsDBNull(0)) { q_id = reader.GetInt32(0); }
				else { q_id = 0; }
				if (!reader.IsDBNull(1)) { q_body = reader.GetString(1); }
				else { q_body = "unknown"; }
				if (!reader.IsDBNull(2)) { q_score = reader.GetInt32(2); }
				else { q_score = 0; }
				if (!reader.IsDBNull(3)) { q_title = reader.GetString(3); }
				else { q_title = "unknown"; }
				if (!reader.IsDBNull(4)) { q_date = reader.GetDateTime(4); }
				else { q_date = DateTime.MinValue; }
				//if (!reader.IsDBNull(5)) { q_oid = reader.GetDateTime(4); }
				//else { q_date = DateTime.MinValue; }

				var question = new Question
				{
					Id = q_id,
					Body = q_body,
					Score = q_score,
					Title = q_title,
					CreationDate = q_date
				};
				return question;
			}
			return null;
		}

		private string 
	}
}
