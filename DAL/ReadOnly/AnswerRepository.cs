using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ReadOnly
{
	public class AnswerRepository : Repository<Answer>
	{
		public AnswerRepository(IDataMapper<Answer> dataMapper) : base(dataMapper) { }
	}
}
