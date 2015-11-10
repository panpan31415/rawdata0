using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebService.Models;

namespace portfolio2gr4.Controllers
{
	public abstract class BaseApiController : ApiController
	{
		ModelFactory _modelFactory;

		public ModelFactory ModelFactory
		{
			get
			{
				if (_modelFactory == null)
				{
					_modelFactory = new ModelFactory(Request);
				}
				return _modelFactory;
			}
		}
	}
}