using DAL.ReadOnly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Rewrittable

{
    public class Annotation: IIdentityField
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }

    }
}