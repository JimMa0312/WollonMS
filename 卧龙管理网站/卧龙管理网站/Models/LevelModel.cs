using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WollonMe.Models
{
    public class Level
    {
        public int LevelId { set; get; }
        public string LevelName { set; get; }
    }
}