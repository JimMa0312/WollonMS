﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WollonMe.Models
{
    [Table("Position")]
    public class PositionModel
    {
        [Key]
        public int PositionID { get; set; }
        public string PositionName { get; set; }
    }
}