using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WollonMe.Models
{
    public class GroupModel
    {
        [Key]
        public int GroupID { get; set; }
        public string GroupName { get; set; }

    }
}