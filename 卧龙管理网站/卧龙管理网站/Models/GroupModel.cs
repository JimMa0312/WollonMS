using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using 卧龙管理网站.Models;

namespace WollonMe.Models

{
    public class Group
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public virtual List<ApplicationUser> Users { get; set; }
    }

}