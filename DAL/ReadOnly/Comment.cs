using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Comment
    {
        public int id { get; set; }
        public int postId { get; set; }
        public string text { get; set; }
        public DateTime creationDate { get; set; }
        public int userid { get; set; }
    }
}
