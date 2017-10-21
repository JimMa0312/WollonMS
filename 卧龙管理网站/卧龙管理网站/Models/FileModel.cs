using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WollonMe.Models
{
    public class File
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FileKind { get; set; }
        public string FileUrl { get; set; }
        public DateTime UpTime { get; set; }
    }
}