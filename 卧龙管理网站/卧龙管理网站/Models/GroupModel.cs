using System;
using System.ComponentModel.DataAnnotations;

namespace WollonMe.Models

{

    public class GroupModel

    {

        [Key]

        public int GroupID { get; set; }

        public string GroupName { get; set; }



    }

}