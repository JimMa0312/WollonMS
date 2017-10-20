using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WollonMe.Models
{
    [Table("Level")]
    public class LevelModel
    {
        [Key]
        public int LevelID { set; get; }
        public string LevelName { set; get; }
    }
}