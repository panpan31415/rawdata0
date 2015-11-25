
﻿using DAL.Rewrittable;
using System;
using portfolio2gr4.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using DAL;

namespace portfolio2gr4.Controllers
{
	public class HistorysController : BaseApiController
	{
		static HistoryMapper dataMapper = new HistoryMapper(ConfigurationManager.ConnectionStrings["remote"].ConnectionString);
		HistoryRepository _hisRepository = new HistoryRepository(dataMapper);

		public IEnumerable<HistoryModel> Get()
		{
			var helper = new UrlHelper(Request);
			return _hisRepository.GetAll()
				.Select(history => ModelFactory.Create(history));
		}

		public HttpResponseMessage GetById(int id)
		{
			var helper = new UrlHelper(Request);
			var history = _hisRepository.GetById(id);
			if (history == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);

			}
			return Request.CreateResponse(
				HttpStatusCode.OK
				, ModelFactory.Create(history));

		}
		public HttpResponseMessage Post([FromBody] HistoryModel model)
		{
			var helper = new UrlHelper(Request);
			var history = ModelFactory.Parse(model);
			_hisRepository.Insert(history);
			return Request.CreateResponse(
				HttpStatusCode.Created
				, ModelFactory.Create(history));
		}

	}
}
