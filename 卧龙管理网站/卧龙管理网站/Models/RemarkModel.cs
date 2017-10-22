using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using 卧龙管理网站.Models;

namespace WollonMe.Models
{
    public class Remark
    {
        public int RemarkId { set; get; }
        public string RemarkCont { set; get; }
        public DateTime RemarkTime { set; get; }
        public int Floor { set; get; }
        public int ToFloor { set; get; }
        public Boolean IsView { set; get; }

        public string UserId { set; get; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public int BlogId { set; get; }
        [ForeignKey("BlogId")]
        public virtual Blog Blog { set; get; }
    }
}