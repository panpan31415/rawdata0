﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class UserRepository : Repository<User>
	{
		public UserRepository(IDataMapper<User> dataMapper) : base(dataMapper) { }
	}
}
