using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WollonMe.Models

{
    [Table("Group")]
    public class GroupModel
    {

        [Key]

        public int GroupID { get; set; }

        public string GroupName { get; set; }
    }

}