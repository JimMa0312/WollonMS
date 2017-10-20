﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WollonMe.Models
{
    [Table("PerKind")]
    public class PerKindModel
    {
        [Key]
        public int PerKindID { set; get; }
        public string PerKindName { set; get; }
    }
}