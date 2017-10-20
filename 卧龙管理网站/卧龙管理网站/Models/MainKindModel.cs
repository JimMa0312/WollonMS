﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WollonMe.Models
{
    [Table("MainKind")]
    public class MainKindModel
    {
        [Key]
        public int MainKindID { set; get; }
        public string MainKindName { set; get; }
    }
}