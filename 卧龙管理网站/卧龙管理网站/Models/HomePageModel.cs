using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WollonMe.Models
{
    public class HomePage
    {
        public int HomePageId { set; get; }
        public string HomePageTitle { set; get; }
        public string HomePageDes { set; get; }
    }
}