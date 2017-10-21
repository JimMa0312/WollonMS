using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WollonMe.Models
{
    public class Remark
    {
        public int RemarkId { set; get; }
        public string RemarkCont { set; get; }
        public string UserID { set; get; }
        public DateTime RemarkTime { set; get; }
        public int Floor { set; get; }
        public int ToFloor { set; get; }
        public Boolean isView { set; get; }

        
        public int BlogID { set; get; }
        public virtual BlogModel Blog { set; get; }
    }
}