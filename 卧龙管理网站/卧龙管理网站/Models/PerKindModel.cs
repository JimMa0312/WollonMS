﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WollonMe.Models
{
    public class PerKind
    {
        public int PerKindId { set; get; }
        public string PerKindName { set; get; }
    }
}