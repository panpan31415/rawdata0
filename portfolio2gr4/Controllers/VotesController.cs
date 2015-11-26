﻿using DAL.Rewrittable;
using portfolio2gr4.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;

namespace portfolio2gr4.Controllers
{
	public class VotesController : BaseApiController
	{
		static VoteMapper dataMapper = new VoteMapper(ConfigurationManager.ConnectionStrings["remote"].ConnectionString);
		VoteRepository _votesRepository = new VoteRepository(dataMapper);

		public IEnumerable<VoteModel> Get(int qid) {
			var helper = new UrlHelper(Request);
			return _votesRepository.GetByPost(qid).Select(vote => ModelFactory.Create(vote));
		}

		public HttpResponseMessage Post([FromBody] VoteModel model )
		{
			var helper = new UrlHelper(Request);
			var vote = ModelFactory.Parse(model);
			_votesRepository.Insert(vote);
			return Request.CreateResponse(
				HttpStatusCode.Created
				, ModelFactory.Create(vote));
		}
	}
}