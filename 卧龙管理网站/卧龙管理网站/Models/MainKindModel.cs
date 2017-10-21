using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WollonMe.Models
{
    public class MainKind
    {
        public int MainKindId { set; get; }
        public string MainKindName { set; get; }
    }
}