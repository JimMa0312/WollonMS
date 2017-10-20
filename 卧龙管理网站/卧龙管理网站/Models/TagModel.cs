using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WollonMe.Models
{
    [Table("Tag")]
    public class TagModel
    {
        [Key]
        public int TagID { set; get; }
        public string TagName { set; get; }
    }
}