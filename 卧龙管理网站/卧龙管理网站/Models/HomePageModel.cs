using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using 卧龙管理网站.Models;

namespace WollonMe.Models
{
    [Table("HomePage")]
    public class HomePageModel
    {
        [Key]
        public string HomePageID { set; get; }
        public string HomePageTitle { set; get; }
        public string HomePageDes { set; get; }
    }
}