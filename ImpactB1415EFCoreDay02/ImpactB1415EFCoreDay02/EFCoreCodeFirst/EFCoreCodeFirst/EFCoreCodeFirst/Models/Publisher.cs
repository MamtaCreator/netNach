using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreCodeFirst.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long ContactNo { get; set; }
        [StringLength(75)]
        public string Email { get; set; }
    }
}
