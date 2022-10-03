using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreConnectedDisconnectedApp.Models
{
    public partial class Publisher
    {
        public int PublisherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long ContactNo { get; set; }
        public string Email { get; set; }
    }
}
