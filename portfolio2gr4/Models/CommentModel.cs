using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portfolio2gr4.Models
{
    public class CommentModel
    {
        //public int id { get; set; }
        public int postId { get; set; }
        public string text { get; set; }
        public DateTime creationDate { get; set; }
        public int userid { get; set; }

        //public CommentModel(Comment c)
        //{
        //    postId = c.postId;
        //    text = c.text;
        //    creationDate = c.creationDate;
        //    userid = c.userid;
        //}
    }
}